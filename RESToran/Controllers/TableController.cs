using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RESToran.DataAccess;
using RESToran.Models;
using Microsoft.EntityFrameworkCore;


namespace RESToran.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableController : Controller
    {
        private readonly PostgreSqlContext _context;

        public TableController(PostgreSqlContext context)
        {
            _context = context;
        }

        // GET: Tables from one of the restaurants
        [HttpGet("Restaurant/{id}/all")]
        public async Task<IActionResult> Index(long id)
        {
            var RestaurantTables = _context.Table
                .Where(t => t.RestaurantId == id)
                .ToList();

            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.Restaurant = restaurant;

            return View(RestaurantTables);
        }

        // GET: api/Table/Restaurant/1/Table/1/Info
        [HttpGet("Restaurant/{restId}/{id}/Info")]
        public async Task<IActionResult> Details(long restId, long? id)
        {
          

            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Table
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == restId);
            ViewBag.Restaurant = restaurant;

            return View(table);
        }

        // GET: Restaurant/{restId}/Table/Create
        [HttpGet("Restaurant/{id}/Create")]
        public IActionResult Create(long id)
        {
            return View();
        }

        // POST: Restaurant/{restId}/Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Restaurant/{id}/Create"), ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(long id, [FromForm] Table table)
        {
            if (ModelState.IsValid)
            {
                table.RestaurantId = id;
                var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == id);

                long NbrOfRestaurantTables = _context.Table
                                .Where(t => t.RestaurantId == id).Count();
                // set RestName with restaurant name and  number of tables in it +1
                int number = (int) NbrOfRestaurantTables + 1;
                table.RestName_Number = restaurant.Name + " " + number.ToString();

                _context.Add(table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = id });
            }
            return View(table);
        }

        // GET: api/Table/Restaurant/1/Edit/1
        [HttpGet("Restaurant/{restId}/Edit/{id}")]
        public async Task<IActionResult> Edit(long restId, long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Table.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == restId);
            ViewBag.Restaurant = restaurant;

            return View(table);
        }

        // POST: api/Table/Restaurant/1/Edit/1
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Restaurant/{restId}/Edit/{id}"), ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long restId, long id, [FromForm] Table table)
        {
            if (id != table.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                table.RestaurantId = restId;
                
                try
                {
                    _context.Update(table);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableExists(table.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = restId });
            }
            return View(table);
        }

        // GET: api/Restaurant/{restId}/Table/Delete/{id}
        [HttpGet("Restaurant/{restId}/Delete/{id}")]
        public async Task<IActionResult> Delete(long? id, long restId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Table
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == restId);
            ViewBag.Restaurant = restaurant;
            return View(table);
        }

        // POST: Table/Delete/5
        [HttpPost("Restaurant/{restId}/Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id, long restId)
        {
            var table = await _context.Table.FindAsync(id);
            _context.Table.Remove(table);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = restId });
        }

        private bool TableExists(long id)
        {
            return _context.Table.Any(e => e.Id == id);
        }
    }
}
