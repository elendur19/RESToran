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
    public class MainCourseController : Controller
    {
        private readonly PostgreSqlContext _context;

        public MainCourseController(PostgreSqlContext context)
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

            var RestaurantMainCoursees = _context.MainCourse
                .Where(t => t.RestaurantId == restaurant.Id)
                .ToList();

            ViewBag.Restaurant = restaurant;

            return View(RestaurantMainCoursees);
        }

        // display all restaurant MainCourses
        // FOR DESKTOP APP
        [HttpGet("Restaurant/desktopApp/all")]
        public async Task<JsonResult> MainCourses()
        {

            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            List<MainCourseInfo> mainCoursesToReturn = new List<MainCourseInfo>();

            List<MainCourse> restaurantMainCoursees = await _context.MainCourse
                                .Where(d => d.RestaurantId == restaurant.Id)
                                .ToListAsync();

            // add mainCourse to mainCourse representation model class
            foreach (MainCourse mainCourse in restaurantMainCoursees)
            {
                MainCourseInfo mainCourseInfo = new MainCourseInfo(mainCourse.Name, mainCourse.Price, mainCourse.Description, mainCourse.HouseSpecial);
                mainCoursesToReturn.Add(mainCourseInfo);
            }

            return new JsonResult(mainCoursesToReturn);
        }

        // display restaurant MainCourse details
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

            var mainCourse = await _context.MainCourse
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mainCourse == null)
            {
                return NotFound();
            }

            ViewBag.Restaurant = restaurant;
            return View(mainCourse);
        }

        // display restaurant MainCourse details
        // FOR DESKTOP APP
        [HttpGet("Restaurant/desktopApp/info")]
        public async Task<JsonResult> Info()
        {

            string mainCourseName = Request.Headers["mainCourseName"];
            // check if mainCourse exists in database
            if (!MainCourseNameExists(mainCourseName))
            {
                // mainCourse not found
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("MainCourse doesn't exist");
            }

            var mainCourse = await _context.MainCourse
                .FirstOrDefaultAsync(d => d.Name.Equals(mainCourseName));

            return new JsonResult(new MainCourseInfo(mainCourse.Name, mainCourse.Price, mainCourse.Description, mainCourse.HouseSpecial));
        }

        
/*        [Authorize]
        [HttpGet("Restaurant/{id}/MainCourse/Create")]
        public IActionResult Create(long id)
        {
           
            ViewBag.RestId = id;
            return View();
        }*/

        // create new restaurant MainCourse
        // FOR DESKTOP APP
        [Authorize]
        [HttpPost("Restaurant/create"), ActionName("Create")]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateMainCourse([FromBody] MainCourseInfo mainCourseInfo)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            if(checkMainCourseNameInSameRestaurant(mainCourseInfo.Name, restaurant.Id))
            {
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("MainCourse "  + mainCourseInfo.Name + " already exists in restaurant");
            }

            MainCourse newMainCourse = new MainCourse();

            newMainCourse.Name = mainCourseInfo.Name;
            newMainCourse.Description = mainCourseInfo.Description;
            newMainCourse.Price = mainCourseInfo.Price;
            newMainCourse.HouseSpecial = mainCourseInfo.HouseSpecial;

            if (ModelState.IsValid)
            {
                newMainCourse.RestaurantId = restaurant.Id;

                _context.Add(newMainCourse);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index), new { id = id });
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("MainCourse successfully created");
        }

        // GET edit form for restaurant MainCourse
        // FOR DESKTOP APP
        [Authorize]
        [HttpGet("Restaurant/edit")]
        public async Task<JsonResult> Edit()
        {
            string mainCourseName = Request.Headers["mainCourseName"];
            // check if mainCourse exists in database
            if (!MainCourseNameExists(mainCourseName))
            {
                // mainCourse not found
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("MainCourse doesn't exist");
            }

            var mainCourse = await _context.MainCourse
                .FirstOrDefaultAsync(d => d.Name.Equals(mainCourseName));

            HttpContext.Response.StatusCode = 200;
            return new JsonResult(new MainCourseInfo(mainCourse.Name, mainCourse.Price, mainCourse.Description, mainCourse.HouseSpecial));
        }

        // POST
        // edit restaurant MainCourse
        // FOR DESKTOP APP
        [Authorize]
        [HttpPost("Restaurant/edit"), ActionName("Update")]
        public async Task<IActionResult> EditMainCourse([FromBody] MainCourseInfo mainCourseInfo)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            string mainCourseName = Request.Headers["mainCourseName"];

            MainCourse mainCourseToUpdate = await _context.MainCourse
                                            .Where(d => d.Name.Equals(mainCourseName))
                                            .FirstOrDefaultAsync();

            mainCourseToUpdate.Name = mainCourseInfo.Name;
            mainCourseToUpdate.Price = mainCourseInfo.Price;
            mainCourseToUpdate.Description = mainCourseInfo.Description;
            mainCourseToUpdate.HouseSpecial = mainCourseInfo.HouseSpecial;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainCourseToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;  
                } 
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("MainCourse successfully updated");
        }

        /*        // GET: MainCourses/Delete/5
                [Authorize]
                [HttpGet("Restaurant/{restId}/MainCourse/Delete/{id}")]
                public async Task<IActionResult> Delete(long? id, long restId)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var mainCourse = await _context.MainCourse
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (mainCourse == null)
                    {
                        return NotFound();
                    }
                    var restaurant = await _context.Restaurant
                        .FirstOrDefaultAsync(m => m.Id == restId);
                    ViewBag.Restaurant = restaurant;
                    return View(mainCourse);
                }*/

        // DELETE
        // delete restaurant MainCourse
        // FOR DESKTOP APP
        [Authorize]
        [HttpDelete("Restaurant/delete"), ActionName("Delete")]
        public async Task<JsonResult> DeleteMainCourse()
        {
            string mainCourseName = Request.Headers["mainCourseName"];
            // check if mainCourse exists in database
            if (!MainCourseNameExists(mainCourseName))
            {
                // mainCourse not found
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("MainCourse doesn't exist");
            }

            MainCourse mainCourseToDelete = await _context.MainCourse
                                            .Where(d => d.Name.Equals(mainCourseName))
                                            .FirstOrDefaultAsync();

            _context.MainCourse.Remove(mainCourseToDelete);
            await _context.SaveChangesAsync();

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("MainCourse successfully deleted");
        }

        private bool MainCourseExists(long id)
        {
            return _context.MainCourse.Any(e => e.Id == id);
        }

        private bool MainCourseNameExists(string mainCourseName)
        {
            return _context.MainCourse.Any(d => d.Name.Equals(mainCourseName));
        }

        // check if mainCourse with exist in current restaurant with same name
        private bool checkMainCourseNameInSameRestaurant(string mainCourseName, long restaurantId)
        {
            return _context.MainCourse.Any(d => d.Name.Equals(mainCourseName) &&
                                        d.RestaurantId == restaurantId);
        }
    }
}
