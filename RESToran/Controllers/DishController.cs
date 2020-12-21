using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESToran.DataAccess;
using RESToran.Models;
using Microsoft.EntityFrameworkCore;

namespace RESToran.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishController : Controller
    {
        private readonly PostgreSqlContext _context;

        public DishController(PostgreSqlContext context)
        {
            _context = context;
        }

        // GET: /Restaurant/{restId}/all
        [HttpGet("Restaurant/{id}/all")]
        public async Task<IActionResult> Index(long id)
        {
            var RestaurantDishes = _context.Dish
                .Where(t => t.RestaurantId == id)
                .ToList();

            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.Restaurant = restaurant;

            return View(RestaurantDishes);
        }

        // GET: Restaurant/{restId}/Dish/{id}/Info
        [HttpGet("Restaurant/{restId}/Dish/{id}/Info")]
        public async Task<IActionResult> Details(long? id, long restId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dish
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == restId);
            ViewBag.Restaurant = restaurant;
            return View(dish);
        }

        // GET: Restaurant/{id}/Dish/Create
        [HttpGet("Restaurant/{id}/Dish/Create")]
        public IActionResult Create(long id)
        {
           
            ViewBag.RestId = id;
            return View();
        }

        // POST: Dishes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Restaurant/{id}/Dish/Create"), ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(long id, [FromForm] Dish dish)
        {
            


            if (ModelState.IsValid)
            {
                dish.RestaurantId = id;
                _context.Add(dish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = id });
            }
            return View(dish);
        }

        // GET: Dishes/Edit/5
        [HttpGet("Restaurant/{restId}/Edit/{id}")]
        public async Task<IActionResult> Edit(long restId, long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dish.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == restId);
            ViewBag.Restaurant = restaurant;
            return View(dish);
        }

        // POST: Dishes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Restaurant/{restId}/Edit/{id}"), ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long restId, long id, [FromForm] Dish dish)
        {
            if (id != dish.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                dish.RestaurantId = restId;
                try
                {
                    _context.Update(dish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishExists(dish.Id))
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
            return View(dish);
        }

        // GET: Dishes/Delete/5
        [HttpGet("Restaurant/{restId}/Dish/Delete/{id}")]
        public async Task<IActionResult> Delete(long? id, long restId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dish
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == restId);
            ViewBag.Restaurant = restaurant;
            return View(dish);
        }

        // POST: Dishes/Delete/5
        [HttpPost("Restaurant/{restId}/Dish/Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id, long restId)
        {
            var dish = await _context.Dish.FindAsync(id);
            _context.Dish.Remove(dish);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id=restId});
        }

        private bool DishExists(long id)
        {
            return _context.Dish.Any(e => e.Id == id);
        }
    }
}
