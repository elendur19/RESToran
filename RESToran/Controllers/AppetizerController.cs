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
    public class AppetizerController : Controller
    {
        private readonly PostgreSqlContext _context;

        public AppetizerController(PostgreSqlContext context)
        {
            _context = context;
        }

        // display all restaurant MainCourses
        // WEBPAGE
        [HttpGet("Restaurant/all")]
        public async Task<IActionResult> Index()
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            var RestaurantAppetizers = _context.Appetizer
               .Where(t => t.RestaurantId == restaurant.Id)
               .ToList();

            ViewBag.Restaurant = restaurant;

            return View(RestaurantAppetizers);
        }

        // display all restaurant Appetiezers
        // FOR DESKTOP APP
        [HttpGet("Restaurant/desktopApp/all")]
        public async Task<JsonResult> Appetiezers()
        {

            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            List<AppetizerInfo> appetiezersToReturn = new List<AppetizerInfo>();

            List<Appetizer> restaurantAppetizers = await _context.Appetizer
                                .Where(d => d.RestaurantId == restaurant.Id)
                                .ToListAsync();

            foreach (Appetizer appetizer in restaurantAppetizers)
            {
                AppetizerInfo appetizerInfo = new AppetizerInfo(appetizer.Name, appetizer.Price, appetizer.Description, appetizer.HouseSpecial);
                appetiezersToReturn.Add(appetizerInfo);
            }

            return new JsonResult(appetiezersToReturn);
        }

        // GET: Appetizer/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appetizer = await _context.Appetizer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appetizer == null)
            {
                return NotFound();
            }

            return View(appetizer);
        }

        // display restaurant Appetizer details
        // FOR DESKTOP APP
        [HttpGet("Restaurant/desktopApp/info")]
        public async Task<JsonResult> Info()
        {

            string appetizerName = Request.Headers["appetizerName"];
            // check if appetizer exists in database
            if (!AppetizerNameExists(appetizerName))
            {
                // appetizerName not found
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Appetizer doesn't exist");
            }

            var appetizer = await _context.Appetizer
                .FirstOrDefaultAsync(d => d.Name.Equals(appetizerName));

            return new JsonResult(new AppetizerInfo(appetizer.Name, appetizer.Price, appetizer.Description, appetizer.HouseSpecial));
        }

        /*        // GET: Appetizer/Create
                public IActionResult Create()
                {
                    return View();
                }
        */

        // create new restaurant MainCourse
        // FOR DESKTOP APP
        [Authorize]
        [HttpPost("Restaurant/create"), ActionName("Create")]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateAppetizer([FromBody] AppetizerInfo appetiezerInfo)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            if (checkAppetizerNameInSameRestaurant(appetiezerInfo.Name, restaurant.Id))
            {
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Appetiezer " + appetiezerInfo.Name + " already exists in restaurant");
            }

            Appetizer newAppetizer = new Appetizer
            {
                Name = appetiezerInfo.Name,
                Description = appetiezerInfo.Description,
                Price = appetiezerInfo.Price,
                HouseSpecial = appetiezerInfo.HouseSpecial
            };

            if (ModelState.IsValid)
            {
                newAppetizer.RestaurantId = restaurant.Id;

                _context.Add(newAppetizer);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index), new { id = id });
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Appetizer successfully created");
        }

        // GET: Appetizer/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appetizer = await _context.Appetizer.FindAsync(id);
            if (appetizer == null)
            {
                return NotFound();
            }
            return View(appetizer);
        }

        // edit restaurant Appetizer
        // FOR DESKTOP APP
        [Authorize]
        [HttpPost("Restaurant/edit"), ActionName("Update")]
        public async Task<IActionResult> EditAppetizer([FromBody] AppetizerInfo appetizerInfo)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            string appetizerName = Request.Headers["appetizerName"];

            Appetizer appetizerToUpdate = await _context.Appetizer
                                            .Where(d => d.Name.Equals(appetizerName))
                                            .FirstOrDefaultAsync();

            appetizerToUpdate.Name = appetizerInfo.Name;
            appetizerToUpdate.Price = appetizerInfo.Price;
            appetizerToUpdate.Description = appetizerInfo.Description;
            appetizerToUpdate.HouseSpecial = appetizerInfo.HouseSpecial;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appetizerToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Appetizer successfully updated");
        }

        // GET: Appetizer/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appetizer = await _context.Appetizer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appetizer == null)
            {
                return NotFound();
            }

            return View(appetizer);
        }

        // DELETE
        // delete restaurant Appetizer
        // FOR DESKTOP APP
        [Authorize]
        [HttpDelete("Restaurant/delete"), ActionName("Delete")]
        public async Task<JsonResult> DeleteAppetizer()
        {
            string appetizerName = Request.Headers["appetizerName"];
            // check if appetizer exists in database
            if (!AppetizerNameExists(appetizerName))
            {
                // mainCourse not found
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Appetizer doesn't exist");
            }

            Appetizer appetizerToDelete = await _context.Appetizer
                                            .Where(d => d.Name.Equals(appetizerName))
                                            .FirstOrDefaultAsync();

            _context.Appetizer.Remove(appetizerToDelete);
            await _context.SaveChangesAsync();

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Appetizer successfully deleted");
        }

        private bool AppetizerExists(long id)
        {
            return _context.Appetizer.Any(e => e.Id == id);
        }

        private bool AppetizerNameExists(string appetizerName)
        {
            return _context.Appetizer.Any(d => d.Name.Equals(appetizerName));
        }

        // check if Appetizer with exist in current restaurant with same name
        private bool checkAppetizerNameInSameRestaurant(string appetizerName, long restaurantId)
        {
            return _context.Appetizer.Any(d => d.Name.Equals(appetizerName) &&
                                        d.RestaurantId == restaurantId);
        }
    }
}
