using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCGarage.Data;
using MVCGarage.Models.Entities;
using MVCGarage.Models.ViewModels;

namespace MVCGarage.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly MVCGarageContext _context;
        private IConfiguration _configuration;

        public ParkedVehiclesController(MVCGarageContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //public string ParkedTime(DateTime arrivalTime)
        //{
        //    return DateTime.Now.Subtract(arrivalTime).ToString();
        //}

        // GET: ParkedVehicles
        public async Task<IActionResult> Index(ListViewModel lwmPost)
        {
            if (_context.ParkedVehicle != null)
            {
                var lwm = new ListViewModel();
                lwm.VehicleList = await _context.ParkedVehicle
                    .WhereIf(lwmPost.searchRegistrationNumber != null, x => x.RegistrationNumber != null && x.RegistrationNumber.StartsWith(lwmPost.searchRegistrationNumber!.Trim()))
                    .WhereIf(lwmPost.searchBrand != null, x => x.Brand != null && x.Brand.StartsWith(lwmPost.searchBrand!.Trim()))
                    .WhereIf(lwmPost.searchWheelCount != null, x => x.WheelCount == lwmPost.searchWheelCount)
                    .WhereIf(lwmPost.searchModel != null, x => x.Model != null && x.Model.StartsWith(lwmPost.searchModel!.Trim()))
                    .WhereIf(lwmPost.searchType != null, x => x.Type == lwmPost.searchType)
                    .Select(v => new IndexParkedVehicleViewModel()
                {
                    Id = v.Id,
                    RegistrationNumber = v.RegistrationNumber,
                    Type = v.Type,
                    ArrivalTime = v.ArrivalTime,
                    //ParkedTime = ParkedTime(arrivalTime)
                    //ParkedTime = DateTime.Now.Subtract(v.ArrivalTime).ToString()
                    ParkedTime = DateTime.Now.Subtract(v.ArrivalTime)
                }).ToListAsync();
                
                return View(lwm);
            }
            else return Problem("Entity set 'MVCGarageContext.ParkedVehicle'  is null.");
        }

        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            var model = new DetailsViewModel
            {
                ArrivalTime = parkedVehicle.ArrivalTime,
                Brand = parkedVehicle.Brand,
                Color = parkedVehicle.Color,
                Id = parkedVehicle.Id,
                Model = parkedVehicle.Model,
                RegistrationNumber = parkedVehicle.RegistrationNumber,
                Type = parkedVehicle.Type,
                WheelCount = parkedVehicle.WheelCount,
                ParkedTime = DateTime.Now.Subtract(parkedVehicle.ArrivalTime)
            };

            return View(model);
        }

        // GET: ParkedVehicles/Create
        public IActionResult Park()
        {
            var pvm = new ParkViewModel();
            pvm.Price = int.Parse(_configuration["Price:HourPrice"]);
            return View(pvm);
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Park(ParkViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                pvm.Error = "";
                var parkedVehicle = new ParkedVehicle
                {
                    Brand = pvm.Brand,
                    Color = pvm.Color,
                    Id = pvm.Id,
                    Model = pvm.Model,
                    RegistrationNumber = pvm.RegistrationNumber,
                    Type = pvm.Type,
                    WheelCount = pvm.WheelCount,
                    ArrivalTime = DateTime.Now
                };

                _context.Add(parkedVehicle);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch(Microsoft.EntityFrameworkCore.DbUpdateException e)
                {
                    if(e.InnerException.Message.StartsWith("Cannot insert duplicate"))
                        pvm.Error = "The RegistrationNumber does already excist, Your vehicle is already parked. Try modifying the vehicle instead.";
                    else
                    {
                        //TODO: Log the error somewhere
                        pvm.Error = "Your vehicle was not Parked due to an error";
                        
                    }
                    return View(pvm);
                }
                catch
                {
                    //TODO: Log the error somewhere
                    pvm.Error = "Your vehicle was not Parked due to an error";
                    return View(pvm);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pvm);
        }

        // GET: ParkedVehicles/Edit/5
        public async Task<IActionResult> Modify(int? id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            var parkedVehicleVM = new ChangeViewModel()
            {
                Id = parkedVehicle.Id,
                Brand = parkedVehicle.Brand,
                Color = parkedVehicle.Color,
                //Colors = Enum.GetValues<Color>()
                //                .Select(g => new SelectListItem
                //                {
                //                    Text = g.ToString(),
                //                    Value = g.ToString()
                //                })
                //                .ToList(),
                Model = parkedVehicle.Model,
                RegistrationNumber = parkedVehicle.RegistrationNumber,
                Type = parkedVehicle.Type,
                WheelCount = parkedVehicle.WheelCount

            };
            return View(parkedVehicleVM);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modify(ChangeViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_context.ParkedVehicle == null)
                        return NotFound();

                    var ParkedVehicleOriginal = await _context.ParkedVehicle
                        .FirstOrDefaultAsync(m => m.Id == cvm.Id);

                    if (ParkedVehicleOriginal == null)
                        return NotFound();

                    ParkedVehicleOriginal.WheelCount = cvm.WheelCount;
                    ParkedVehicleOriginal.Model = cvm.Model;
                    ParkedVehicleOriginal.RegistrationNumber = cvm.RegistrationNumber;
                    ParkedVehicleOriginal.Brand = cvm.Brand;
                    ParkedVehicleOriginal.Color = cvm.Color;
                    ParkedVehicleOriginal.Type = cvm.Type;

                    //TODO ModelState(ParkedVehicleOriginal).IsValid ???

                    _context.ParkedVehicle.Attach(ParkedVehicleOriginal);
                    //+_context.Entry(ParkedVehicleOriginal).Property(x => x.ArrivalTime).IsModified = false;
                    await _context.SaveChangesAsync();

                    //_context.Update(parkedVehicle);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(cvm.Id))
                        return NotFound();
                    else
                        throw;

                }
                return RedirectToAction(nameof(Index));
            }

            return View(cvm);
        }

        // GET: ParkedVehicles/Checkout/5
        public async Task<IActionResult> Checkout(int? id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            var parkedTime = DateTime.Now.Subtract(parkedVehicle.ArrivalTime);

            var cvm = new CheckoutViewModel()
            {
                ArrivalTime = parkedVehicle.ArrivalTime,
                Brand = parkedVehicle.Brand,
                Color = parkedVehicle.Color,
                CheckoutTime = DateTime.Now,
                Id = parkedVehicle.Id,
                Model = parkedVehicle.Model,
                Price = calculatePrice(parkedTime.TotalHours),
                ParkedTime = parkedTime,
                RegistrationNumber = parkedVehicle.RegistrationNumber,
                Type = parkedVehicle.Type,
                WheelCount = parkedVehicle.WheelCount
            };

            return View(cvm);
        }

        private decimal calculatePrice(double totalHour)
        {
            int iHourPrice = int.Parse(_configuration["Price:HourPrice"]);
            return (decimal)(totalHour * iHourPrice);
        }

        // POST: ParkedVehicles/Checkout/5
        [HttpPost, ActionName("Checkout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckoutConfirmed(int id)
        {
            if (_context.ParkedVehicle == null)
            {
                return Problem("Entity set 'MVCGarageContext.ParkedVehicle'  is null.");
            }

            ReceiptViewModel rvm = new ReceiptViewModel();
            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle != null)
            {
                _context.ParkedVehicle.Remove(parkedVehicle);

                var parkedTime = DateTime.Now.Subtract(parkedVehicle.ArrivalTime);
                //TODO decide what cost per minute is, hardcoded to 20kr per minute

                rvm = new ReceiptViewModel()
                {
                    ArrivalTime = parkedVehicle.ArrivalTime,
                    Brand = parkedVehicle.Brand,
                    Color = parkedVehicle.Color,
                    CheckoutTime = DateTime.Now,
                    Model = parkedVehicle.Model,
                    Price = calculatePrice(parkedTime.TotalHours),
                    ParkedTime = parkedTime,
                    RegistrationNumber = parkedVehicle.RegistrationNumber,
                    Type = parkedVehicle.Type
                };
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Receipt), rvm);
        }

        public IActionResult Receipt(ReceiptViewModel rvm)
        {
            return View(rvm);
        }

        private bool ParkedVehicleExists(int id)
        {
            return (_context.ParkedVehicle?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
