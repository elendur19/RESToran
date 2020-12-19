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
    [Route("api/[controller]")]
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

            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.Restaurant = restaurant;

            return View(RestaurantTables);
        }

        // GET: Table/Details/5
        [HttpGet("Restaurant/{restId}/TableInfo/{id}")]
        public async Task<IActionResult> Details(long restId, long? id)
        {
            var RestaurantTables = _context.Table
                .Where(t => t.RestaurantId == restId)
                .ToList();

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

            return View(table);
        }

        // GET: Table/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RestaurantId,Location,NumberOfSeats")] Table table)
        {
            if (ModelState.IsValid)
            {
                _context.Add(table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(table);
        }

        // GET: Table/Edit/5
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

            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(m => m.Id == restId);
            ViewBag.Restaurant = restaurant;

            return View(table);
        }

        // POST: Table/Edit/5
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

        // GET: Table/Delete/5
        public async Task<IActionResult> Delete(long? id)
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

            return View(table);
        }

        // POST: Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var table = await _context.Table.FindAsync(id);
            _context.Table.Remove(table);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableExists(long id)
        {
            return _context.Table.Any(e => e.Id == id);
        }
    }
}
