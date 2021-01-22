using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESToran.DataAccess;
using RESToran.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using RESToran.DataClasses;
using System;

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

        // display all restaurant Dishes
        // WEBPAGE
        [HttpGet("Restaurant/all")]
        public async Task<IActionResult> Index(long id)
        {

            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            var RestaurantDishes = _context.Dish
                .Where(t => t.RestaurantId == restaurant.Id)
                .ToList();

            ViewBag.Restaurant = restaurant;

            return View(RestaurantDishes);
        }

        // display all restaurant Dishes
        // FOR DESKTOP APP
        [HttpGet("Restaurant/desktopApp/all")]
        public async Task<JsonResult> Dishes(long id)
        {

            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            List<DishInfo> dishesToReturn = new List<DishInfo>();

            List<Dish> restaurantDishes = await _context.Dish
                                .Where(d => d.RestaurantId == restaurant.Id)
                                .ToListAsync();

            // add dish to dish representation model class
            foreach (Dish dish in restaurantDishes)
            {
                DishInfo dishInfo = new DishInfo(dish.Name, dish.Price, dish.Description, dish.HouseSpecial);
                dishesToReturn.Add(dishInfo);
            }

            return new JsonResult(dishesToReturn);
        }

        // display restaurant Dish details
        // WEBPAGE
        [HttpGet("Restaurant/Info")]
        public async Task<IActionResult> Details(long? id)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

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

            ViewBag.Restaurant = restaurant;
            return View(dish);
        }

        // display restaurant Dish details
        // FOR DESKTOP APP
        [HttpGet("Restaurant/desktopApp/info")]
        public async Task<JsonResult> Info()
        {

            string dishName = Request.Headers["dishName"];
            // check if dish exists in database
            if (!DishNameExists(dishName))
            {
                // dish not found
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Dish doesn't exist");
            }

            var dish = await _context.Dish
                .FirstOrDefaultAsync(d => d.Name.Equals(dishName));

            return new JsonResult(new DishInfo(dish.Name, dish.Price, dish.Description, dish.HouseSpecial));
        }

        
/*        [Authorize]
        [HttpGet("Restaurant/{id}/Dish/Create")]
        public IActionResult Create(long id)
        {
           
            ViewBag.RestId = id;
            return View();
        }*/

        // create new restaurant Dish
        // FOR DESKTOP APP
        [Authorize]
        [HttpPost("Restaurant/create"), ActionName("Create")]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateDish([FromBody] DishInfo dishInfo)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            if(checkDishNameInSameRestaurant(dishInfo.Name, restaurant.Id))
            {
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Dish "  + dishInfo.Name + " already exists in restaurant");
            }

            Dish newDish = new Dish();

            newDish.Name = dishInfo.Name;
            newDish.Description = dishInfo.Description;
            newDish.Price = dishInfo.Price;
            newDish.HouseSpecial = dishInfo.HouseSpecial;

            if (ModelState.IsValid)
            {
                newDish.RestaurantId = restaurant.Id;

                _context.Add(newDish);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index), new { id = id });
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Dish successfully created");
        }

        // GET edit form for restaurant Dish
        // FOR DESKTOP APP
        [Authorize]
        [HttpGet("Restaurant/edit")]
        public async Task<JsonResult> Edit(long? id)
        {
            string dishName = Request.Headers["dishName"];
            // check if dish exists in database
            if (!DishNameExists(dishName))
            {
                // dish not found
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Dish doesn't exist");
            }

            var dish = await _context.Dish
                .FirstOrDefaultAsync(d => d.Name.Equals(dishName));

            HttpContext.Response.StatusCode = 200;
            return new JsonResult(new DishInfo(dish.Name, dish.Price, dish.Description, dish.HouseSpecial));
        }

        // POST
        // edit restaurant Dish
        // FOR DESKTOP APP
        [Authorize]
        [HttpPost("Restaurant/edit"), ActionName("Update")]
        public async Task<IActionResult> EditDish([FromBody] DishInfo dishInfo)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            string dishName = Request.Headers["dishName"];

            Dish dishToUpdate = await _context.Dish
                                            .Where(d => d.Name.Equals(dishName))
                                            .FirstOrDefaultAsync();

            dishToUpdate.Name = dishInfo.Name;
            dishToUpdate.Price = dishInfo.Price;
            dishToUpdate.Description = dishInfo.Description;
            dishToUpdate.HouseSpecial = dishInfo.HouseSpecial;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dishToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;  
                } 
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Dish successfully updated");
        }

        /*        // GET: Dishes/Delete/5
                [Authorize]
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
                }*/

        // DELETE
        // delete restaurant Dish
        // FOR DESKTOP APP
        [Authorize]
        [HttpDelete("Restaurant/delete"), ActionName("Delete")]
        public async Task<JsonResult> DeleteDish()
        {
            string dishName = Request.Headers["dishName"];
            // check if dish exists in database
            if (!DishNameExists(dishName))
            {
                // dish not found
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Dish doesn't exist");
            }

            Dish dishToDelete = await _context.Dish
                                            .Where(d => d.Name.Equals(dishName))
                                            .FirstOrDefaultAsync();

            _context.Dish.Remove(dishToDelete);
            await _context.SaveChangesAsync();

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Dish successfully deleted");
        }

        private bool DishExists(long id)
        {
            return _context.Dish.Any(e => e.Id == id);
        }

        private bool DishNameExists(string dishName)
        {
            return _context.Dish.Any(d => d.Name.Equals(dishName));
        }

        // check if dish with exist in current restaurant with same name
        private bool checkDishNameInSameRestaurant(string dishName, long restaurantId)
        {
            return _context.Dish.Any(d => d.Name.Equals(dishName) &&
                                        d.RestaurantId == restaurantId);
        }
    }
}
