using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESToran.DataAccess;
using RESToran.DataClasses;
using RESToran.Models;

namespace RESToran.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DessertController : Controller
    {
        private readonly PostgreSqlContext _context;

        public DessertController(PostgreSqlContext context)
        {
            _context = context;
        }

        // GET: Dessert
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dessert.ToListAsync());
        }

        // display all restaurant Desserts
        // FOR DESKTOP APP
        [HttpGet("Restaurant/desktopApp/all")]
        public async Task<JsonResult> Desserts()
        {

            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            List<DessertInfo> dessertsToReturn = new List<DessertInfo>();

            List<Dessert> restaurantDesserts = await _context.Dessert
                                .Where(d => d.RestaurantId == restaurant.Id)
                                .ToListAsync();

            foreach (Dessert dessert in restaurantDesserts)
            {
                DessertInfo dessertInfo = new DessertInfo(dessert.Name, dessert.Price, dessert.Description, dessert.HouseSpecial);
                dessertsToReturn.Add(dessertInfo);
            }

            return new JsonResult(dessertsToReturn);
        }

        // GET: Dessert/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dessert = await _context.Dessert
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dessert == null)
            {
                return NotFound();
            }

            return View(dessert);
        }

        // display restaurant Dessert details
        // FOR DESKTOP APP
        [HttpGet("Restaurant/desktopApp/info")]
        public async Task<JsonResult> Info()
        {

            string dessertName = Request.Headers["dessertName"];
            // check if dessert exists in database
            if (!DessertNameExists(dessertName))
            {
                // dessertName not found
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Dessert doesn't exist");
            }

            var dessert = await _context.Dessert
                .FirstOrDefaultAsync(d => d.Name.Equals(dessertName));

            return new JsonResult(new DessertInfo(dessert.Name, dessert.Price, dessert.Description, dessert.HouseSpecial));
        }

        /*        // GET: Dessert/Create
                public IActionResult Create()
                {
                    return View();
                }*/

        // create new restaurant Dessert
        // FOR DESKTOP APP
        [Authorize]
        [HttpPost("Restaurant/create"), ActionName("Create")]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateDessert([FromBody] DessertInfo dessertInfo)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            if (checkDessertNameInSameRestaurant(dessertInfo.Name, restaurant.Id))
            {
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Dessert " + dessertInfo.Name + " already exists in restaurant");
            }

            Dessert newDessert = new Dessert
            {
                Name = dessertInfo.Name,
                Description = dessertInfo.Description,
                Price = dessertInfo.Price,
                HouseSpecial = dessertInfo.HouseSpecial
            };

            if (ModelState.IsValid)
            {
                newDessert.RestaurantId = restaurant.Id;

                _context.Add(newDessert);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index), new { id = id });
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Dessert successfully created");
        }

        // GET: Dessert/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dessert = await _context.Dessert.FindAsync(id);
            if (dessert == null)
            {
                return NotFound();
            }
            return View(dessert);
        }

        // edit restaurant Dessert
        // FOR DESKTOP APP
        [Authorize]
        [HttpPost("Restaurant/edit"), ActionName("Update")]
        public async Task<IActionResult> EditDessert([FromBody] DessertInfo dessertInfo)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            string dessertName = Request.Headers["dessertName"];

            Dessert dessertToUpdate = await _context.Dessert
                                            .Where(d => d.Name.Equals(dessertName))
                                            .FirstOrDefaultAsync();

            dessertToUpdate.Name = dessertInfo.Name;
            dessertToUpdate.Price = dessertInfo.Price;
            dessertToUpdate.Description = dessertInfo.Description;
            dessertToUpdate.HouseSpecial = dessertInfo.HouseSpecial;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dessertToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Dessert successfully updated");
        }

        // GET: Dessert/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dessert = await _context.Dessert
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dessert == null)
            {
                return NotFound();
            }

            return View(dessert);
        }

        // DELETE
        // delete restaurant Dessert
        // FOR DESKTOP APP
        [Authorize]
        [HttpDelete("Restaurant/delete"), ActionName("Delete")]
        public async Task<JsonResult> DeleteDessert()
        {
            string dessertName = Request.Headers["dessertName"];
            // check if dessert exists in database
            if (!DessertNameExists(dessertName))
            {
                // dessert not found
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Dessert doesn't exist");
            }

            Dessert dessertToDelete = await _context.Dessert
                                            .Where(d => d.Name.Equals(dessertName))
                                            .FirstOrDefaultAsync();

            _context.Dessert.Remove(dessertToDelete);
            await _context.SaveChangesAsync();

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Dessert successfully deleted");
        }

        private bool DessertExists(long id)
        {
            return _context.Dessert.Any(e => e.Id == id);
        }

        private bool DessertNameExists(string dessertName)
        {
            return _context.Dessert.Any(d => d.Name.Equals(dessertName));
        }

        // check if Dessert with exist in current restaurant with same name
        private bool checkDessertNameInSameRestaurant(string dessertName, long restaurantId)
        {
            return _context.Dessert.Any(d => d.Name.Equals(dessertName) &&
                                        d.RestaurantId == restaurantId);
        }
    }
}
