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
    public class ParkedVehiclesController : Controller
    {
        private readonly MVCGarageContext _context;
        private readonly IOptions<PriceSettings> options;

        public ParkedVehiclesController(MVCGarageContext context, IOptions<PriceSettings> options)
        {
            _context = context;
            this.options = options;
        }

        public async Task<IActionResult> Index(ListViewModel lvm)
        {
            if (_context.ParkedVehicle != null)
            {
                //if ((lvm.SearchType != null) 
                //    || !string.IsNullOrEmpty(lvm.SearchBrand) 
                //    || !string.IsNullOrEmpty(lvm.SearchModel) 
                //    || (lvm.SearchWheelCount != null))
                //    lvm.HasSearchItem = true;

                lvm.HasSearchItem = 
                    lvm.SearchType != null || lvm.SearchWheelCount != null ||
                    !string.IsNullOrEmpty(lvm.SearchBrand) || !string.IsNullOrEmpty(lvm.SearchModel);

                var dbParkedVehicles = await _context.ParkedVehicle
                    .WhereIf(lvm.SearchRegistrationNumber != null, x => x.RegistrationNumber != null && x.RegistrationNumber.StartsWith(lvm.SearchRegistrationNumber!.Trim()))
                    .WhereIf(lvm.SearchBrand != null, x => x.Brand != null && x.Brand.StartsWith(lvm.SearchBrand!.Trim()))
                    .WhereIf(lvm.SearchWheelCount != null, x => x.WheelCount == lvm.SearchWheelCount)
                    .WhereIf(lvm.SearchModel != null, x => x.Model != null && x.Model.StartsWith(lvm.SearchModel!.Trim()))
                    .WhereIf(lvm.SearchType != null, x => x.Type == lvm.SearchType)
                    .Select(v => new IndexParkedVehicleViewModel()
                    {
                        Id = v.Id,
                        RegistrationNumber = v.RegistrationNumber,
                        Type = v.Type,
                        ArrivalTime = v.ArrivalTime,
                        ParkedTime = DateTime.Now.Subtract(v.ArrivalTime)
                    }).ToListAsync();
                
                var orderedParkedVehicles =
                    lvm.Order == Order.RegistrationNumber ? dbParkedVehicles.OrderAscOrDesc(lvm.Desc, v => v.RegistrationNumber)
                  : lvm.Order == Order.Type ? dbParkedVehicles.OrderAscOrDesc(lvm.Desc, v => v.Type)
                  : lvm.Order == Order.ParkedTime ? dbParkedVehicles.OrderAscOrDesc(lvm.Desc, v => v.ParkedTime)
                  : dbParkedVehicles.OrderAscOrDesc(lvm.Desc, v => v.ArrivalTime);

                lvm.VehicleList = orderedParkedVehicles.ToList();

                return View(lvm);
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
            pvm.Price = options.Value.HourPrice;
            return View(pvm);
        }

        public string minifyAndUpperCaseString(string stringToMinify)
        {
            return stringToMinify.Replace(" ", "").Replace("-", "");
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
                pvm.RegistrationNumber = minifyAndUpperCaseString(pvm.RegistrationNumber!);
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
                bool bModifySuccess = true;
                try
                {
                    if (_context.ParkedVehicle == null)
                        return NotFound();

                    cvm.RegistrationNumber = minifyAndUpperCaseString(cvm.RegistrationNumber!);
                    cvm.Error = "";
                    var parkedVehicle = new ParkedVehicle()
                    {
                        Id = cvm.Id,
                        WheelCount = cvm.WheelCount,
                        Model = cvm.Model,
                        RegistrationNumber = cvm.RegistrationNumber,
                        Brand = cvm.Brand,
                        Color = cvm.Color,
                        Type = cvm.Type
                    };

                    _context.Update(parkedVehicle);
                    _context.Entry(parkedVehicle).Property(x => x.ArrivalTime).IsModified = false;
                    
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
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    bModifySuccess = false;
                    if (!ParkedVehicleExists(cvm.Id))
                        return NotFound();
                    else
                        cvm.Error = "Your vehicle was not modified due to an error";

                }
                cvm.ModifySuccess = bModifySuccess;
                return View(cvm);
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
                Price = CalculatePrice(parkedTime.TotalHours),
                ParkedTime = parkedTime,
                RegistrationNumber = parkedVehicle.RegistrationNumber,
                Type = parkedVehicle.Type,
                WheelCount = parkedVehicle.WheelCount
            };

            return View(cvm);
        }

        private decimal CalculatePrice(double totalHour)
        {
            int iHourPrice = options.Value.HourPrice;
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

                rvm = new ReceiptViewModel()
                {
                    ArrivalTime = parkedVehicle.ArrivalTime,
                    Brand = parkedVehicle.Brand,
                    Color = parkedVehicle.Color,
                    CheckoutTime = DateTime.Now,
                    Model = parkedVehicle.Model,
                    Price = CalculatePrice(parkedTime.TotalHours),
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
