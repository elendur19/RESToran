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
    public class DrinkController : Controller
    {
        private readonly PostgreSqlContext _context;

        public DrinkController(PostgreSqlContext context)
        {
            _context = context;
        }

        // GET: Drink
        [HttpGet("Restaurant/all")]
        public async Task<IActionResult> Index()
        {
            // get Restaurant id back
            string restId = HttpContext.Request.Query["id"].ToString();
            long id = long.Parse(restId);

            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == id);

            var RestaurantDrink = _context.Drink
               .Where(d => d.RestaurantId == restaurant.Id)
               .ToList();

            ViewBag.Restaurant = restaurant;

            return View(RestaurantDrink);
        }

        // display all restaurant Drinks
        // FOR DESKTOP APP
        [HttpGet("Restaurant/desktopApp/all")]
        public async Task<JsonResult> Drinks()
        {

            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            List<DrinkInfo> drinksToReturn = new List<DrinkInfo>();

            List<Drink> restaurantDrinks = await _context.Drink
                                .Where(d => d.RestaurantId == restaurant.Id)
                                .ToListAsync();

            foreach (Drink drink in restaurantDrinks)
            {
                DrinkInfo drinkInfo = new DrinkInfo(drink.Name, drink.Price, drink.Description, drink.HouseSpecial, drink.AgeRestricted);
                drinksToReturn.Add(drinkInfo);
            }

            return new JsonResult(drinksToReturn);
        }

        // GET: Drink/Details/5
        [HttpGet("Restaurant/info")]
        public async Task<IActionResult> Details()
        {
            // get Restaurant id back
            string drinkId = HttpContext.Request.Query["id"].ToString();
            long id = long.Parse(drinkId);

            var drink = await _context.Drink
                .FirstOrDefaultAsync(d => d.Id == id);

            if (drink == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.Id == drink.RestaurantId)
                                        .FirstOrDefaultAsync();

            ViewBag.Restaurant = restaurant;

            return View(drink);
        }

        // display restaurant Drink details
        // FOR DESKTOP APP
        [HttpGet("Restaurant/desktopApp/info")]
        public async Task<JsonResult> Info()
        {

            string drinkName = Request.Headers["drinkName"];
            // check if drink exists in database
            if (!DrinkNameExists(drinkName))
            {
                // drinkName not found
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Drink doesn't exist");
            }

            var drink = await _context.Drink
                .FirstOrDefaultAsync(d => d.Name.Equals(drinkName));

            return new JsonResult(new DrinkInfo(drink.Name, drink.Price, drink.Description, drink.HouseSpecial, drink.AgeRestricted));
        }
        /*
                // GET: Drink/Create
                public IActionResult Create()
                {
                    return View();
                }*/

        // create new restaurant Drink
        // FOR DESKTOP APP
        [Authorize]
        [HttpPost("Restaurant/create"), ActionName("Create")]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateDrink([FromBody] DrinkInfo drinkInfo)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            if (checkDrinkNameInSameRestaurant(drinkInfo.Name, restaurant.Id))
            {
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Drink " + drinkInfo.Name + " already exists in restaurant");
            }

            Drink newDrink = new Drink
            {
                Name = drinkInfo.Name,
                Description = drinkInfo.Description,
                Price = drinkInfo.Price,
                HouseSpecial = drinkInfo.HouseSpecial,
                AgeRestricted = drinkInfo.AgeRestricted
            };

            if (ModelState.IsValid)
            {
                newDrink.RestaurantId = restaurant.Id;

                _context.Add(newDrink);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index), new { id = id });
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Drink successfully created");
        }

        // edit restaurant Drink
        // FOR DESKTOP APP
        [Authorize]
        [HttpPost("Restaurant/edit"), ActionName("Update")]
        public async Task<IActionResult> EditDrink([FromBody] DrinkInfo drinkInfo)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            string drinkName = Request.Headers["drinkName"];

            Drink drinkToUpdate = await _context.Drink
                                            .Where(d => d.Name.Equals(drinkName))
                                            .FirstOrDefaultAsync();

            drinkToUpdate.Name = drinkInfo.Name;
            drinkToUpdate.Price = drinkInfo.Price;
            drinkToUpdate.Description = drinkInfo.Description;
            drinkToUpdate.HouseSpecial = drinkInfo.HouseSpecial;
            drinkToUpdate.AgeRestricted = drinkInfo.AgeRestricted;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drinkToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Drink successfully updated");
        }

        // GET: Drink/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);
        }

        // DELETE
        // delete restaurant Drink
        // FOR DESKTOP APP
        [Authorize]
        [HttpDelete("Restaurant/delete"), ActionName("Delete")]
        public async Task<JsonResult> DeleteDrink()
        {
            string drinkName = Request.Headers["drinkName"];
            // check if drink exists in database
            if (!DrinkNameExists(drinkName))
            {
                // drink not found
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Drink doesn't exist");
            }

            Drink drinkToDelete = await _context.Drink
                                            .Where(d => d.Name.Equals(drinkName))
                                            .FirstOrDefaultAsync();

            _context.Drink.Remove(drinkToDelete);
            await _context.SaveChangesAsync();

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Drink successfully deleted");
        }

        private bool DrinkExists(long id)
        {
            return _context.Drink.Any(e => e.Id == id);
        }
        private bool DrinkNameExists(string drinkName)
        {
            return _context.Drink.Any(d => d.Name.Equals(drinkName));
        }

        // check if Drink with exist in current restaurant with same name
        private bool checkDrinkNameInSameRestaurant(string drinkName, long restaurantId)
        {
            return _context.Drink.Any(d => d.Name.Equals(drinkName) &&
                                        d.RestaurantId == restaurantId);
        }
    }
}
