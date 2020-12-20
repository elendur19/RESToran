 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RESToran.DataAccess;
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
            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.Restaurant = restaurant;

            return View(await _context.ReservationPeriod.ToListAsync());
        }

        // GET: ReservationPeriod/Details/5
        [HttpGet("Restaurant/{restId}/info/{id}")]
        public async Task<IActionResult> Details(long? id)
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

            return View(reservationPeriod);
        }

        // GET: create form for new reservation period
        [HttpGet("Restaurant/{id}/new-reservation")]
        public async Task<IActionResult> Create(long id)
        {
            var restaurantTables = await _context.Table
                .Where(t => t.RestaurantId == id)
                .ToListAsync();
            var tables = restaurantTables
                         .Select(x =>
                                    new SelectListItem
                                    {
                                        Value = x.Id.ToString(),
                                        Text = "Table number " + x.Id.ToString()
                                    });

            ViewData["Tables"] = new SelectList(tables, "Value", "Text");
            //IEnumerable<long> RestaurantTableIds = RestaurantTables.Select(x => x.Id).ToList();
            //ViewBag.TableIds = RestaurantTableIds;
            return View();
        }

        // POST: ReservationPeriod/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Restaurant/{id}/new-reservation"), ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(long id, [FromForm] ReservationPeriod reservationPeriod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationPeriod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = id });
            }
            return View(reservationPeriod);
        }

        // GET: ReservationPeriod/Edit/5
        [HttpGet("Restaurant/{restId}/edit/{id}")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationPeriod = await _context.ReservationPeriod.FindAsync(id);
            if (reservationPeriod == null)
            {
                return NotFound();
            }
            return View(reservationPeriod);
        }

        // POST: ReservationPeriod/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,TableId,Date,StartTime,EndTime")] ReservationPeriod reservationPeriod)
        {
            if (id != reservationPeriod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationPeriod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationPeriodExists(reservationPeriod.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reservationPeriod);
        }

        // GET: ReservationPeriod/Delete/5
        [HttpGet("Restaurant/{restId}/delete/{id}")]
        public async Task<IActionResult> Delete(long? id)
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

            return View(reservationPeriod);
        }

        // POST: ReservationPeriod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var reservationPeriod = await _context.ReservationPeriod.FindAsync(id);
            _context.ReservationPeriod.Remove(reservationPeriod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationPeriodExists(long id)
        {
            return _context.ReservationPeriod.Any(e => e.Id == id);
        }
    }
}
