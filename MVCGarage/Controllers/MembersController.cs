using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVCGarage.Data;
using MVCGarage.Models.Entities;
using MVCGarage.Models.ViewModels.Members;
using Personnummer;

namespace MVCGarage.Controllers
{
    public class MembersController : Controller
    {
        private readonly MVCGarageContext _context;
        private readonly IOptions<PriceSettings> options;

        public MembersController(MVCGarageContext context, IOptions<PriceSettings> options)
        {
            _context = context;
            this.options = options;
        }

        public async Task<IActionResult> Index(ListViewModel lvm)
        {
            if (_context.Member != null)
            {
                lvm.HasExpandedSearchItem = !string.IsNullOrEmpty(lvm.SearchName);

                var dbMembers = await _context.Member!
                    .WhereIf(lvm.SearchPersonalIdentityNumber != null, x => x.PersonalIdentityNumber != null && EF.Functions.Like(x.PersonalIdentityNumber, $"%{lvm.SearchPersonalIdentityNumber!.Trim()}%"   ))
                    .WhereIf(lvm.SearchName != null, x => (x.FirstName != null && x.FirstName.StartsWith(lvm.SearchName!.Trim())) || (x.LastName != null && x.LastName.StartsWith(lvm.SearchName!.Trim())))
                    .Select(m => new IndexMemberViewModel()
                    {
                        Id = m.Id,
                        
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                        BirthDate = $"{(m.PersonalIdentityNumber ?? "????????").Substring(0, 8)}-XXXX",
                        NrOfVehicles = m.Vehicles.Count
                    })
                    .ToListAsync();
                lvm.MemberList = dbMembers;
                dbMembers.Sort(new TwoFirstCaseSensitiveOnModelsFirstname());
                return View(lvm);                
            }
            else return Problem("Entity set 'MVCGarageContext.Member'  is null.");
        }

        public class TwoFirstCaseSensitiveOnModelsFirstname : IComparer<Object>
        {
            public int Compare(object? x, object? y)
            {
                var xModel = x as IndexMemberViewModel;
                var yModel = y as IndexMemberViewModel;

                return string.Compare(xModel?.FirstName, 0, yModel?.FirstName, 0, 2, false);
            }
        }

        // GET
        public IActionResult Register()
        {
            var amvm = new RegisterViewModel();
            return View(amvm);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel amvm)
		{
            if (ModelState.IsValid)
            {
                var member = new Member()
                {
                    PersonalIdentityNumber = new Personnummer.Personnummer(amvm.PersonalIdentityNumber).Format(true),
                    FirstName = amvm.FirstName,
                    LastName = amvm.LastName
                };

                _context.Add(member);

                await _context.SaveChangesAsync();
                amvm.RegisterSuccess = true;
            }

            return View(amvm);
        }

        public async Task<IActionResult> CheckIfPINIsUnique(string personalIdentityNumber)
        {
            try
            {
                if (await _context.Member.AnyAsync(m => m.PersonalIdentityNumber == personalIdentityNumber))
                    return Json("A member with that personal identity number is already registered.");
            }
            catch
            {
            }
            //if database messed up on validation it is not a big deal if this was not validated (since it is not to be trusted once we reach backend), we validate once more on database index
            return Json(true);
        }

        // GET: Vehicles/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var Member = await _context.Member
                .Include(m => m.Vehicles)
                .ThenInclude(v => v.VehicleAssignments)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Member == null)
            {
                return NotFound();
            }

            DetailsViewModel model;
            try
            {
                model = await getDetailsForMember(id);
            }
            catch (MemberNotFoundException e)
            {
                return NotFound();
            }
            return View(model);
        }

        public (bool, List<PSpot>) FindFirstAvailableSpots(float NeededSize)
        {
            var retList = new List<PSpot>();
            if (_context.PSpot == null)
                return (false, retList);
            
            if (NeededSize < 1)
            {
                var allPSpots = _context.PSpot
                    .Include(p => p.VehicleAssignments)
                    .ThenInclude(va => va.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                    .ToList();
                //We need to see if there still is room in already taken PSpots
                foreach (PSpot pSpot in allPSpots)
                {
                    float alreadyUsedSizeInSpotTotal = 0f;
                    foreach (VehicleAssignment va in pSpot.VehicleAssignments)
                    {
                        alreadyUsedSizeInSpotTotal += va.Vehicle.VehicleType.NeededSize;
                    }
                    //would it fit here?
                    if ((alreadyUsedSizeInSpotTotal + NeededSize) <= 1)
                    {
                        //Yup return there is room and what available spots to use
                        retList.Add(pSpot);
                        return (true, retList);
                    }
                }
            }

            if(NeededSize >= 1)
            {
                var allEmptyPSpots = _context.PSpot
                    .Where(p => p.VehicleAssignments.Count == 0).ToList();

                //Is there room for this vehicle?
                int NeededSizeRoundedUp = (int)Math.Ceiling(NeededSize);
                if(NeededSizeRoundedUp <= allEmptyPSpots.Count)
                {
                    //Yes there is room, return first [amount PSpots needed] PSpots
                    for(int i=0;i<NeededSizeRoundedUp;i++)
                        retList.Add(allEmptyPSpots[i]);                        

                    return (true, retList);
                }
            }

            //We failed to find any available pSpots to use for NeededSize
            return (false, retList);
        }

        // GET: Vehicles/Details/5
        [HttpPost]
        public async Task<IActionResult> Details(DetailsViewModel dvm)
        {
            //if optional parameter wasParked was sent here, user tried to park a vehicle, show message informing user of park success
            bool bSuccess = true;
            string parkFailedReason = string.Empty;
            if (dvm == null || _context.Member == null)
                return NotFound();        
            if (dvm.VehicleId == null)
                return NotFound();

            var MemberVehicle = await _context.Vehicle
                .Include(v => v.VehicleType)
                .Where(v => v.Id == dvm.VehicleId).FirstOrDefaultAsync();
            if (MemberVehicle == null)
            { 
                bSuccess = false;
                parkFailedReason = "Vehicle was not found";
            }

            try
            { 
                var SpotsResult = FindFirstAvailableSpots(MemberVehicle!.VehicleType.NeededSize);
            
                if(SpotsResult.Item1)
                {
                    //We found out there is available spots, let's use those spots
                    foreach(PSpot pspot in SpotsResult.Item2)
                    _context.VehicleAssignment.Add(new VehicleAssignment()
                    {
                        ArrivalDate = DateTime.Now,
                        PSpotId = pspot.Id,
                        Vehicle = MemberVehicle
                    });
                    await _context.SaveChangesAsync();
                }
                else
                {
                    bSuccess = false;
                    parkFailedReason = $"There is not enough room left to park a {MemberVehicle!.VehicleType.Name}";
                }
            }
            catch
            {
                bSuccess = false;
                parkFailedReason = "Could not park vehicle in any spots";
            }

            //Reload page but show infobox for success or not
            DetailsViewModel model;
            try
            { 
                model = await getDetailsForMember(dvm.Id);
                model.ParkSuccess = bSuccess;
                if (bSuccess)
                {
                    model.modalTitleText = $"{MemberVehicle!.VehicleType.Name} {MemberVehicle!.RegistrationNumber} is now parked.";
                    model.modalBodyText = "Use Checkout when unparking your vehicle.";
                }
                else
                {
                    model.modalTitleText = $"{MemberVehicle!.VehicleType.Name} {MemberVehicle!.RegistrationNumber} was not parked.";
                    model.modalBodyText = parkFailedReason;
                }
            }
            catch (MemberNotFoundException e)
            {
                return NotFound();
            }
            return View(model);
        }

        public async Task<DetailsViewModel> getDetailsForMember(int? id)
        {
            var Member = await _context.Member
                .Include(m => m.Vehicles)
                .ThenInclude(v => v.VehicleAssignments)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Member == null)
                throw new MemberNotFoundException();

            var model = new DetailsViewModel
            {
                Id = Member.Id,
                FirstName = Member.FirstName,
                LastName = Member.LastName,
                Type = new Membership(Member.ProMembershipToDate).Type,
                Vehicles = Member.Vehicles.Select(v => new MemberVehicleModel()
                {
                    Id = v.Id,
                    Brand = v.Brand,
                    Model = v.Model,
                    RegistrationNumber = v.RegistrationNumber,
                    IsParked = v.VehicleAssignments.Count > 0
                }).ToList()
            };
            return model;
        }
    }
}
