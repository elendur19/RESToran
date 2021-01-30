 using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RESToran.DataAccess;
using RESToran.DataClasses;
using RESToran.Models;

namespace RESToran.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationPeriodController : Controller
    {
        private readonly PostgreSqlContext _context;

        public ReservationPeriodController(PostgreSqlContext context)
        {
            _context = context;
        }

        // GET: all reservation periods for restaurant
        [HttpGet("Restaurant/{id}/all")]
        public async Task<IActionResult> Index(long id)
        {
            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.Restaurant = restaurant;

            var table = await _context.Table.Where(rt => rt.RestaurantId == id).ToListAsync();
            ViewBag.Tables = table;

            // get reservation periods for restaurant with id from url
            var restaurantReservationPeriods = await _context.ReservationPeriod
                        .Where(rp => rp.RestaurantId == id)
                        .ToListAsync();



            return View(restaurantReservationPeriods);
        }

        // GET: ReservationPeriod/Details/5
        [HttpGet("Restaurant/{restId}/ReservationPeriod/{id}/Info")]
        public async Task<IActionResult> Details(long? id, long restId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationPeriod = await _context.ReservationPeriod
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationPeriod == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == restId);
            ViewBag.Restaurant = restaurant;
            return View(reservationPeriod);
        }

        // GET: create form for new reservation period
        [HttpGet("Restaurant/{id}/ReservationPeriod/new-reservation")]
        public async Task<IActionResult> Create(long id)
        {
            var restaurantTables = await _context.Table
                .Where(t => t.RestaurantId == id)
                .ToListAsync();

            var tables = restaurantTables
                         .Select(x =>
                                    new SelectListItem
                                    {
                                        Value = x.Description,
                                        Text = x.Description
                                    });

            ViewData["Tables"] = new SelectList(tables, "Value", "Text").GroupBy(x => x.Text)
                                                .Select(x => x.FirstOrDefault());

            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.Restaurant = restaurant;
            //IEnumerable<long> RestaurantTableIds = RestaurantTables.Select(x => x.Id).ToList();
            //ViewBag.TableIds = RestaurantTableIds;
            ViewBag.RestId = id;
       
            return View();
        }

        // POST: ReservationPeriod/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Restaurant/{id}/ReservationPeriod/new-reservation"), ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(long id, [FromForm] ReservationPeriod reservationPeriod)
        {

            // provjeri je li datum u prošlosti
            CultureInfo us = new CultureInfo("en-US");
            string format = "yyyy-MM-dd";
            DateTime dt1 = DateTime.ParseExact(reservationPeriod.Date, format, us);

            if (dt1 < DateTime.Now)
            {
                //date is in the past, return bad date request 
                return RedirectToAction(nameof(DateInPastRequest), new
                {
                    id = id,
                    date = reservationPeriod.Date
                });
            }

            string pom;
            pom = reservationPeriod.Date;

            int year = int.Parse(pom.Substring(0, 4));
            int month = int.Parse(pom.Substring(5, 2));
            int day = int.Parse(pom.Substring(8, 2));


            string str_day = day.ToString("D2");
            string str_month = month.ToString("D2");
            string str_year = year.ToString("D4");

            // formatiraj datum dd/MM/yyyy
            reservationPeriod.Date = str_day + "/" + str_month + "/" + str_year;

            // provjeri je li start time veci od end time-a

            pom = reservationPeriod.StartTime.ToString("HH:mm");
            int NewPeriodMinuteStart = int.Parse(pom.Substring(0, 2)) * 60 + int.Parse(pom.Substring(3, 2));
            pom = reservationPeriod.EndTime.ToString("HH:mm");
            int NewPeriodMinuteEnd = int.Parse(pom.Substring(0, 2)) * 60 + int.Parse(pom.Substring(3, 2));
            string description = reservationPeriod.TableDescription;

            if (NewPeriodMinuteStart > NewPeriodMinuteEnd)
            {
                // odi na bad time request view i posalji potrebne parametre
                return RedirectToAction(nameof(InvalidStartEndTimeRequest), new
                {
                    id = id,
                    startTime = reservationPeriod.StartTime,
                    endTime = reservationPeriod.EndTime
                });
            }

            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == id);

            List<Table> tables =  _context.Table
                    .Where(t => t.RestaurantId == id)
                    .Where(t => t.Description.Equals(description))
                    .ToList();

            List<long> tableIds = tables.Select(t => t.Id).ToList();

            List<long> reservationPeriodTablesIds = _context.ReservationPeriod
                                    .Where(rp => rp.RestaurantId == id)
                                    .Where(rp => rp.TableDescription.Equals(reservationPeriod.TableDescription))
                                    .Select(rp => rp.TableId)
                                    .Distinct()
                                    .ToList();

            // TODO : implement reservation logic
            bool found = false;
             foreach (var table in tables) {
                if (reservationPeriodTablesIds.Contains(table.Id))
                {
                    // vec postoji rezervacija za stol sa id-om table.Id, provjeri jel se moze napraviti nova rez.
                    List<ReservationPeriod> reservationPeriods = _context.ReservationPeriod
                                                .Where(rp => rp.RestaurantId == id)
                                                .Where(rp => rp.TableId == table.Id)
                                                .ToList();
                    foreach (ReservationPeriod period in reservationPeriods)
                    {

                        string reservationPeriodDate = reservationPeriod.Date;
                        // get database reservation Period info
                        string dbReservatinPeriodDate = period.Date;
                        int dbYear = int.Parse(dbReservatinPeriodDate.Substring(6, 4));
                        int dbMonth = int.Parse(dbReservatinPeriodDate.Substring(3, 2));
                        int dbDay = int.Parse(dbReservatinPeriodDate.Substring(0, 2));

                        int rpYear = int.Parse(reservationPeriodDate.Substring(6, 4));
                        int rpMonth = int.Parse(reservationPeriodDate.Substring(3, 2));
                        int rpDay = int.Parse(reservationPeriodDate.Substring(0, 2));

                        bool sameDay = (dbYear == rpYear && dbMonth == rpMonth && dbDay == rpDay); 
                        //if (NewPeriodMinuteStart >= NewPeriodMinuteEnd) break;

                        // datum su jednaki, usporedi vremena
                        if (sameDay)
                        {
                            pom = period.StartTime.ToString("HH:mm");
                            int DbPeriodMinuteStart= int.Parse(pom.Substring(0, 2)) * 60 + int.Parse(pom.Substring(3, 2)); 
                            pom = period.EndTime.ToString("HH:mm");
                            int DbPeriodMinuteEnd= int.Parse(pom.Substring(0, 2)) * 60 + int.Parse(pom.Substring(3, 2));

                            if ((NewPeriodMinuteStart >= DbPeriodMinuteStart && NewPeriodMinuteStart <= DbPeriodMinuteEnd) ||
                                (NewPeriodMinuteEnd >= DbPeriodMinuteStart && NewPeriodMinuteEnd <= DbPeriodMinuteEnd) ||
                                (NewPeriodMinuteStart <= DbPeriodMinuteStart && NewPeriodMinuteEnd >= DbPeriodMinuteEnd) ||
                                (NewPeriodMinuteStart >= DbPeriodMinuteStart && NewPeriodMinuteEnd <= DbPeriodMinuteEnd))
                            {
                                // preklapa se sa postojecim terminom
                                continue;
                            } else
                            {
                                // termin je slobodan za stol 
                                found = true;
                                reservationPeriod.TableId = table.Id;
                                break;
                            }
                        }
                    }
                    // ako si rezervirao termin , izadi
                    if (found == true)
                    {
                        break; 
                    }
                } else
                {
                    // uopce ne postoji rezervation period za ovaj stol, odmah rezerviraj stol

                    pom = reservationPeriod.Date;

                    int yearToSave = int.Parse(reservationPeriod.Date.Substring(6, 4));
                    int monthToSave = int.Parse(reservationPeriod.Date.Substring(3, 2));
                    int dayToSave = int.Parse(reservationPeriod.Date.Substring(0, 2));

                    string str_dayToSave = day.ToString("D2");
                    string str_monthToSave = month.ToString("D2");
                    string str_yearToSave = year.ToString("D4");

                    // formatiraj datum dd/MM/yyyy

                    reservationPeriod.Date = str_day + "/" + str_month + "/" + str_year;
                    
                    reservationPeriod.TableId = table.Id;
                    found = true;
                    break;
                }
             }

             if (found == false)
            {
                // odi na bad request view i posalji potrebne paramtre
                return RedirectToAction(nameof(BadTimeRequest), new {
                    id = id,
                    date = reservationPeriod.Date,
                    startTime = reservationPeriod.StartTime,
                    endTime = reservationPeriod.EndTime
                });
            }

            reservationPeriod.RestaurantId = id;

            if (ModelState.IsValid)
            {

                _context.Add(reservationPeriod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = id });
    
            }
            return View(reservationPeriod);
        }

        // GET Date in Past Request
        [HttpGet("Restaurant/{id}/ReservationPeriod/DateInPastRequest")]
        public async Task<IActionResult> DateInPastRequest(long id, DateTime date)
        {
            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.Restaurant = restaurant;

            string dateString = date.ToString("D",
                   CultureInfo.CreateSpecificCulture("en-USR"));

            ViewBag.Date = dateString;

            return View();
        }

        // GET Invalid Start End Time Request
        [HttpGet("Restaurant/{id}/ReservationPeriod/InvalidStartEndTimeRequest")]
        public async Task<IActionResult> InvalidStartEndTimeRequest(long id, DateTime startTime, DateTime endTime)
        {
            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.Restaurant = restaurant;

            string startTimeString = startTime.ToString("t",
                  CultureInfo.CreateSpecificCulture("en-US"));
            string endTimeString = endTime.ToString("t",
                  CultureInfo.CreateSpecificCulture("en-US"));

            ViewBag.StartTime = startTimeString;
            ViewBag.EndStart = endTimeString;

            return View();
        }

        // GET Bad Time Request
        [HttpGet("Restaurant/{id}/ReservationPeriod/BadTimeRequest")]
        public async Task<IActionResult> BadTimeRequest(long id, DateTime date, DateTime startTime, DateTime endTime)
        {
            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.Restaurant = restaurant;

            string dateString = date.ToString("D",
                  CultureInfo.CreateSpecificCulture("en-US"));
            string startTimeString  = startTime.ToString("t",
                  CultureInfo.CreateSpecificCulture("en-US"));
            string endTimeString = endTime.ToString("t",
                  CultureInfo.CreateSpecificCulture("en-US"));

            ViewBag.Date = dateString;

            ViewBag.StartTime = startTimeString;
            ViewBag.EndStart = endTimeString;

            return View();
        }

        // GET SA DATUMOM
        // ZA DESKTOP APP
        [Authorize]
        [HttpGet("Restaurant/date/all")]
        public async Task<JsonResult> ReservationPeriodsOnDate()
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            List<ReservationPeriodInfo> reservationPeriodsToReturn = new List<ReservationPeriodInfo>();

            string rpDate = Request.Headers["dateReservation"];

            // get reservation periods for restaurant with email on date
            var restaurantReservationPeriods = await _context.ReservationPeriod
                        .Where(rp => rp.RestaurantId == restaurant.Id)
                        .Where(rp => rp.Date.Equals(rpDate))
                        .ToListAsync();

            foreach (ReservationPeriod reservationPeriod in restaurantReservationPeriods)
            {
                ReservationPeriodInfo reservationPeriodInfo = new ReservationPeriodInfo(reservationPeriod.Id, reservationPeriod.RestaurantId, reservationPeriod.TableId, 
                                                        reservationPeriod.TableDescription, reservationPeriod.Date, reservationPeriod.StartTime, reservationPeriod.EndTime);
                reservationPeriodsToReturn.Add(reservationPeriodInfo);
            }

            return new JsonResult(restaurantReservationPeriods);
        }

        // GET  
        // ZA DESKTOP APP
        [Authorize]
        [HttpGet("Restaurant/all")]
        public async Task<JsonResult> ReservationPeriods()
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            List<ReservationPeriodInfo> reservationPeriodsToReturn = new List<ReservationPeriodInfo>();

            // get reservation periods for restaurant with email
            var restaurantReservationPeriods = await _context.ReservationPeriod
                        .Where(rp => rp.RestaurantId == restaurant.Id)
                        .ToListAsync();

            foreach (ReservationPeriod reservationPeriod in restaurantReservationPeriods)
            {
                ReservationPeriodInfo reservationPeriodInfo = new ReservationPeriodInfo(reservationPeriod.Id, reservationPeriod.RestaurantId, reservationPeriod.TableId,
                                                        reservationPeriod.TableDescription, reservationPeriod.Date, reservationPeriod.StartTime, reservationPeriod.EndTime);
                reservationPeriodsToReturn.Add(reservationPeriodInfo);
            }

            return new JsonResult(restaurantReservationPeriods);
        }

        // POST: ReservationPeriod/Delete/5
        [HttpPost("Restaurant/{restId}/ReservationPeriod/Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id, long restId)
        {
            var reservationPeriod = await _context.ReservationPeriod.FindAsync(id);
            _context.ReservationPeriod.Remove(reservationPeriod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = restId });
        }

        private bool ReservationPeriodExists(long id)
        {
            return _context.ReservationPeriod.Any(e => e.Id == id);
        }
    }
}
