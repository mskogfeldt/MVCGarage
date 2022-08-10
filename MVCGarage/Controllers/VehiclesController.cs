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
using MVCGarage.Models.ViewModels;

namespace MVCGarage.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly MVCGarageContext _context;
        private readonly IOptions<PriceSettings> options;

        public VehiclesController(MVCGarageContext context, IOptions<PriceSettings> options)
        {
            _context = context;
            this.options = options;
        }

        public async Task<IActionResult> Index(ListViewModel lvm)
        {
            if (_context.Vehicle != null)
            {
                //if ((lvm.SearchType != null) 
                //    || !string.IsNullOrEmpty(lvm.SearchBrand) 
                //    || !string.IsNullOrEmpty(lvm.SearchModel) 
                //    || (lvm.SearchWheelCount != null))
                //    lvm.HasSearchItem = true;

                lvm.HasSearchItem = 
                    lvm.SearchType != null || lvm.SearchWheelCount != null ||
                    !string.IsNullOrEmpty(lvm.SearchBrand) || !string.IsNullOrEmpty(lvm.SearchModel);

                var dbVehicles = await _context.Vehicle!
                    .Join(_context.VehicleAssignment!,
                    v => v.Id,
                    va => va.VehicleId,
                    (v, va) => new { vehicle = v, asgnmt = va })
                    .WhereIf(lvm.SearchRegistrationNumber != null, x => x.vehicle.RegistrationNumber != null && x.vehicle.RegistrationNumber.StartsWith(lvm.SearchRegistrationNumber!.Trim()))
                    .WhereIf(lvm.SearchBrand != null, x => x.vehicle.Brand != null && x.vehicle.Brand.StartsWith(lvm.SearchBrand!.Trim()))
                    .WhereIf(lvm.SearchWheelCount != null, x => x.vehicle.WheelCount == lvm.SearchWheelCount)
                    .WhereIf(lvm.SearchModel != null, x => x.vehicle.Model != null && x.vehicle.Model.StartsWith(lvm.SearchModel!.Trim()))
                    //TODO testa searchtype
                    .WhereIf(lvm.SearchType != null, x => x.vehicle.VehicleType.Id == lvm.SearchType!.Id)
                    .Select(v => new IndexVehicleViewModel()
                    {
                        Id = v.vehicle.Id,
                        RegistrationNumber = v.vehicle.RegistrationNumber,
                        Type = new VehicleType()
                        {
                            Id = v.vehicle.VehicleType.Id,
                            Name = v.vehicle.VehicleType.Name,
                            NeededSize = v.vehicle.VehicleType.NeededSize
                        },
                        ArrivalTime = v.asgnmt.ArrivalDate,
                        ParkedTime = DateTime.Now.Subtract(v.asgnmt.ArrivalDate)
                    })
                    .ToListAsync();

                var orderedVehicles =
                    lvm.Order == Order.RegistrationNumber ? dbVehicles.OrderAscOrDesc(lvm.Desc, v => v.RegistrationNumber)
                  : lvm.Order == Order.Type ? dbVehicles.OrderAscOrDesc(lvm.Desc, v => v.Type)
                  : lvm.Order == Order.ParkedTime ? dbVehicles.OrderAscOrDesc(lvm.Desc, v => v.ParkedTime)
                  : dbVehicles.OrderAscOrDesc(lvm.Desc, v => v.ArrivalTime);

                lvm.VehicleList = orderedVehicles.ToList();
                return View(lvm);                
            }
            else return Problem("Entity set 'MVCGarageContext.Vehicle'  is null.");
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehicle == null || _context.Member == null || _context.VehicleAssignment == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FirstOrDefaultAsync(m => m.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            var va = await _context.VehicleAssignment.FirstOrDefaultAsync(va => va.VehicleId == id);

            var member = await _context.Member.FirstOrDefaultAsync(m => m.Id == vehicle.MemberId);

            if (va == null || member == null)
            {
                return NotFound();
            }


            //await Task.Delay(100);
            //throw new Exception("TODO Arrivaltime changed, type changed");

            var model = new DetailsViewModel
            {
                Brand = vehicle.Brand,
                Color = vehicle.Color,
                Id = vehicle.Id,
                Model = vehicle.Model,
                RegistrationNumber = vehicle.RegistrationNumber,
                VehicleType = vehicle.VehicleType,
                WheelCount = vehicle.WheelCount,
                OwnerFirstName = member.FirstName,
                OwnerLastName = member.LastName,
                ArrivalTime = va.ArrivalDate,
                ParkedTime = DateTime.Now.Subtract(va.ArrivalDate)
            };

            return View(model);

        }

        // GET: Vehicles/Create
        public IActionResult Park()
        {
            var pvm = new ParkViewModel
            {
                Price = options.Value.HourPrice
            };
            return View(pvm);
        }

        public string MinifyAndUpperCaseString(string stringToMinify)
        {
            return stringToMinify.Replace(" ", "").Replace("-", "");
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Park(ParkViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                pvm.RegistrationNumber = MinifyAndUpperCaseString(pvm.RegistrationNumber!);
                pvm.Error = "";
                await Task.Delay(100);
                throw new Exception("TODO Arrivaltime changed, type changed");
                /*
                var Vehicle = new Vehicle
                {
                    Brand = pvm.Brand,
                    Color = pvm.Color,
                    Id = pvm.Id,
                    Model = pvm.Model,
                    RegistrationNumber = pvm.RegistrationNumber,
                    //Type = pvm.Type,
                    WheelCount = pvm.WheelCount
                    //ArrivalTime = DateTime.Now
                };

                _context.Add(Vehicle);
                bool bParkSuccess = true;
                try
                {
                    await _context.SaveChangesAsync();
                }
                //TODO: Log the error somewhere
                catch(DbUpdateException e)
                {
                    if (e.InnerException != null && e.InnerException.Message.StartsWith("Cannot insert duplicate"))
                        pvm.Error = "A vehicle with that registration number is already parked. Try modifying the vehicle instead.";
                    else
                    {
                        pvm.Error = "Your vehicle was not parked due to an error";
                    }
                    bParkSuccess = false;
                }
                catch
                {
                    pvm.Error = "Your vehicle was not parked due to an error";
                    bParkSuccess = false;
                }
                pvm.ParkSuccess = bParkSuccess;
                */
            }            
            return View(pvm);
        }

        public async Task<IActionResult> CheckIfRegIsUnique(string registrationNumber)
        {
            try
            {
                if (await _context.Vehicle!.AnyAsync(v => v.RegistrationNumber == registrationNumber))
                    return Json("A vehicle with that registration number is already parked. Try modifying the vehicle instead.");
            }
            catch
            {                
            }
            //if database messed up on validation it is not a big deal if this was not validated (since it is not to be trusted once we reach backend), we validate once more on database index
            return Json(true);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Modify(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var Vehicle = await _context.Vehicle.FindAsync(id);
            if (Vehicle == null)
            {
                return NotFound();
            }
            await Task.Delay(100);
            throw new Exception("TODO type changed");
            /*
            var VehicleVM = new ChangeViewModel()
            {
                Id = Vehicle.Id,
                Brand = Vehicle.Brand,
                Color = Vehicle.Color,
                //Colors = Enum.GetValues<Color>()
                //                .Select(g => new SelectListItem
                //                {
                //                    Text = g.ToString(),
                //                    Value = g.ToString()
                //                })
                //                .ToList(),
                Model = Vehicle.Model,
                RegistrationNumber = Vehicle.RegistrationNumber,
                //Type = Vehicle.Type,
                WheelCount = Vehicle.WheelCount

            };
            return View(VehicleVM);
            */
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modify(ChangeViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                bool bModifySuccess = true;
                try
                {
                    if (_context.Vehicle == null)
                        return NotFound();

                    cvm.RegistrationNumber = MinifyAndUpperCaseString(cvm.RegistrationNumber!);
                    cvm.Error = "";
                    await Task.Delay(100);
                    throw new Exception("TODO type changed");
                    /*
                    var Vehicle = new Vehicle()
                    {
                        Id = cvm.Id,
                        WheelCount = cvm.WheelCount,
                        Model = cvm.Model,
                        RegistrationNumber = cvm.RegistrationNumber,
                        Brand = cvm.Brand,
                        Color = cvm.Color
                        //Type = cvm.Type
                    };

                    _context.Update(Vehicle);
                    throw new Exception("TODO Arrivaltime changed");
                    //_context.Entry(Vehicle).Property(x => x.ArrivalTime).IsModified = false;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    //TODO: Log the error somewhere
                    catch (DbUpdateException e)
                    {
                        if (e.InnerException != null && e.InnerException.Message.StartsWith("Cannot insert duplicate"))
                            cvm.Error = "The RegistrationNumber does already excist on another car that is also already parked. Checkout that vehicle first.";
                        else
                        {
                            cvm.Error = "Your vehicle was not modified due to an error";
                        }
                        bModifySuccess = false;
                    }
                    catch
                    {
                        cvm.Error = "Your vehicle was not modified due to an error";
                        bModifySuccess = false;
                    }
                    */
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    bModifySuccess = false;
                    if (!VehicleExists(cvm.Id))
                        return NotFound();
                    else
                        cvm.Error = "Your vehicle was not modified due to an error";

                }
                cvm.ModifySuccess = bModifySuccess;
                return View(cvm);
            }
            
            return View(cvm);
        }

        // GET: Vehicles/Checkout/5
        public async Task<IActionResult> Checkout(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var Vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Vehicle == null)
            {
                return NotFound();
            }
            await Task.Delay(100);
            throw new Exception("TODO Arrivaltime changed, type changed");
            /*
            //var parkedTime = DateTime.Now.Subtract(Vehicle.ArrivalTime);

            var cvm = new CheckoutViewModel()
            {
                //ArrivalTime = Vehicle.ArrivalTime,
                Brand = Vehicle.Brand,
                Color = Vehicle.Color,
                CheckoutTime = DateTime.Now,
                Id = Vehicle.Id,
                Model = Vehicle.Model,
                //Price = CalculatePrice(parkedTime.TotalHours),
                //ParkedTime = parkedTime,
                RegistrationNumber = Vehicle.RegistrationNumber,
                //Type = Vehicle.Type,
                WheelCount = Vehicle.WheelCount
            };
            
            return View(cvm);
            */
        }

        private decimal CalculatePrice(double totalHour)
        {
            int iHourPrice = options.Value.HourPrice;
            return (decimal)(totalHour * iHourPrice);
        }

        // POST: Vehicles/Checkout/5
        [HttpPost, ActionName("Checkout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckoutConfirmed(int id)
        {
            if (_context.Vehicle == null)
            {
                return Problem("Entity set 'MVCGarageContext.Vehicle'  is null.");
            }

            ReceiptViewModel rvm = new();
            var Vehicle = await _context.Vehicle.FindAsync(id);
            if (Vehicle != null)
            {
                _context.Vehicle.Remove(Vehicle);

                await Task.Delay(100);
                throw new Exception("TODO Arrivaltime changed, type changed");
                /*
                //var parkedTime = DateTime.Now.Subtract(Vehicle.ArrivalTime);

                rvm = new ReceiptViewModel()
                {
                    //ArrivalTime = Vehicle.ArrivalTime,
                    Brand = Vehicle.Brand,
                    Color = Vehicle.Color,
                    CheckoutTime = DateTime.Now,
                    Model = Vehicle.Model,
                    //Price = CalculatePrice(parkedTime.TotalHours),
                    //ParkedTime = parkedTime,
                    RegistrationNumber = Vehicle.RegistrationNumber
                    //Type = Vehicle.Type
                };
                */
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Receipt), rvm);
        }

        public IActionResult Receipt(ReceiptViewModel rvm)
        {
            return View(rvm);
        }

        private bool VehicleExists(int id)
        {
            return (_context.Vehicle?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
