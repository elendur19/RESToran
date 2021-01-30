using System;
using System.Collections.Generic;
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
    public class SaladController : Controller
    {
        private readonly PostgreSqlContext _context;

        public SaladController(PostgreSqlContext context)
        {
            _context = context;
        }

        // display all restaurant Salads
        // FOR DESKTOP APP
        [HttpGet("Restaurant/desktopApp/all")]
        public async Task<JsonResult> Salads()
        {

            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            List<SaladInfo> saladsToReturn = new List<SaladInfo>();

            List<Salad> restaurantSalads = await _context.Salad
                                .Where(d => d.RestaurantId == restaurant.Id)
                                .ToListAsync();

            foreach (Salad salad in restaurantSalads)
            {
                SaladInfo saladInfo = new SaladInfo(salad.Name, salad.Price, salad.Description, salad.HouseSpecial, salad.Topping);
                saladsToReturn.Add(saladInfo);
            }

            return new JsonResult(saladsToReturn);
        }

        // GET: Salad
        [HttpGet("Restaurant/all")]
        public async Task<IActionResult> Index()
        {
            // get Restaurant id back
            string restId = HttpContext.Request.Query["id"].ToString();
            long id = long.Parse(restId);

            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == id);

            var RestaurantSalads = _context.Salad
               .Where(s => s.RestaurantId == restaurant.Id)
               .ToList();

            ViewBag.Restaurant = restaurant;

            return View(RestaurantSalads);
        }

        // GET: Salad/Details/5
        [HttpGet("Restaurant/info")]
        public async Task<IActionResult> Details()
        {
            // get Restaurant id back
            string saladId = HttpContext.Request.Query["id"].ToString();
            long id = long.Parse(saladId);

            var salad = await _context.Salad
                .FirstOrDefaultAsync(s => s.Id == id);

            if (salad == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.Id == salad.RestaurantId)
                                        .FirstOrDefaultAsync();

            ViewBag.Restaurant = restaurant;

            return View(salad);
        }

        // display restaurant Salad details
        // FOR DESKTOP APP
        [HttpGet("Restaurant/desktopApp/info")]
        public async Task<JsonResult> Info()
        {

            string saladName = Request.Headers["saladName"];
            // check if salad exists in database
            if (!SaladNameExists(saladName))
            {
                // saladName not found
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Salad doesn't exist");
            }

            var salad = await _context.Salad
                .FirstOrDefaultAsync(d => d.Name.Equals(saladName));

            return new JsonResult(new SaladInfo(salad.Name, salad.Price, salad.Description, salad.HouseSpecial, salad.Topping));
        }

        /*        // GET: Salad/Create
                public IActionResult Create()
                {
                    return View();
                }*/

        // create new restaurant Salad
        // FOR DESKTOP APP
        [Authorize]
        [HttpPost("Restaurant/create"), ActionName("Create")]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateSalad([FromBody] SaladInfo saladInfo)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            if (checkSaladNameInSameRestaurant(saladInfo.Name, restaurant.Id))
            {
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Salad " + saladInfo.Name + " already exists in restaurant");
            }

            Salad newSalad = new Salad
            {
                Name = saladInfo.Name,
                Description = saladInfo.Description,
                Price = saladInfo.Price,
                HouseSpecial = saladInfo.HouseSpecial,
                Topping = saladInfo.Topping
            };

            if (ModelState.IsValid)
            {
                newSalad.RestaurantId = restaurant.Id;

                _context.Add(newSalad);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index), new { id = id });
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Salad successfully created");
        }

        // edit restaurant Salad
        // FOR DESKTOP APP
        [Authorize]
        [HttpPost("Restaurant/edit"), ActionName("Update")]
        public async Task<IActionResult> EditSalad([FromBody] SaladInfo saladInfo)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            string saladName = Request.Headers["saladName"];

            Salad saladToUpdate = await _context.Salad
                                            .Where(d => d.Name.Equals(saladName))
                                            .FirstOrDefaultAsync();

            saladToUpdate.Name = saladInfo.Name;
            saladToUpdate.Price = saladInfo.Price;
            saladToUpdate.Description = saladInfo.Description;
            saladToUpdate.HouseSpecial = saladInfo.HouseSpecial;
            saladToUpdate.Topping = saladInfo.Topping;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saladToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Salad successfully updated");
        }

        // GET: Salad/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salad = await _context.Salad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salad == null)
            {
                return NotFound();
            }

            return View(salad);
        }

        // DELETE
        // delete restaurant Salad
        // FOR DESKTOP APP
        [Authorize]
        [HttpDelete("Restaurant/delete"), ActionName("Delete")]
        public async Task<JsonResult> DeleteSalad()
        {
            string saladName = Request.Headers["saladName"];
            // check if salad exists in database
            if (!SaladNameExists(saladName))
            {
                // salad not found
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Salad doesn't exist");
            }

            Salad saladToDelete = await _context.Salad
                                            .Where(d => d.Name.Equals(saladName))
                                            .FirstOrDefaultAsync();

            _context.Salad.Remove(saladToDelete);
            await _context.SaveChangesAsync();

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Salad successfully deleted");
        }

        private bool SaladExists(long id)
        {
            return _context.Salad.Any(e => e.Id == id);
        }
        private bool SaladNameExists(string saladName)
        {
            return _context.Salad.Any(d => d.Name.Equals(saladName));
        }

        // check if Salad with exist in current restaurant with same name
        private bool checkSaladNameInSameRestaurant(string saladName, long restaurantId)
        {
            return _context.Salad.Any(d => d.Name.Equals(saladName) &&
                                        d.RestaurantId == restaurantId);
        }
    }
}
