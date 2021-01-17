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
    public class RestaurantController : Controller
    {
        private readonly PostgreSqlContext _context;

        public RestaurantController(PostgreSqlContext context)
        {
            _context = context;
        }

        // GET: api/Restaurant
        [HttpGet("all")]
        public async Task<IActionResult> Index()
        {
            List<Restaurant> restaurants = await _context.Restaurant.ToListAsync();
            
            return View(restaurants);
        }

        // GET: Restaurant/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurant/Create
        //[HttpGet("Restaurant/Create")]
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /* //[Authorize]
         [HttpPost("create")]
         public async Task<IActionResult> Create([FromForm] Restaurant restaurant)
         {
             if (ModelState.IsValid)
             {
                 _context.Add(restaurant);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(restaurant);
         }*/

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        //[Authorize]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Restaurant_Auth restaurant)
        {
            /*if (ModelState.IsValid)
            {
                _context.Add(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            */

            List<Restaurant> restaurants = await _context.Restaurant.ToListAsync();
            bool found = false;
            // check if restaurant is in db
            restaurants.ForEach(rest =>
            {
               if (rest.EmailAddress.Equals(restaurant.EmailAddress) &&
                   rest.Password.Equals(restaurant.Password))
               {
                    found = true;
               }
            });

            if (found)
            {
                string valueToEncode = restaurant.EmailAddress + ":" + restaurant.Password;
                var textBytes = System.Text.Encoding.UTF8.GetBytes(valueToEncode);
                HttpContext.Response.Headers.Add("AuthValue", System.Convert.ToBase64String(textBytes));
                return View();
            }

            return NotFound();
        }
    
    // GET: Restaurant/Edit/5
        [Authorize]
        [HttpGet("info")]
        public async Task<JsonResult> Info()
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();
            if (restaurant != null)
            {
                HttpContext.Response.StatusCode = 200;
                RestaurantInfo restaurantInfo = new RestaurantInfo();
                
                restaurantInfo.Name = restaurant.Name;
                restaurantInfo.EmailAddress = restaurant.EmailAddress;
                restaurantInfo.Location = restaurant.Location;
                restaurantInfo.PhoneNumber = restaurant.PhoneNumber;
                restaurantInfo.HoursOpened = restaurant.HoursOpened;

                return new JsonResult(restaurantInfo);
            } else
            {
                HttpContext.Response.StatusCode = 401;
                return new JsonResult("Not authorized");
            }
            
            
        }

        
        // edit Restaurant information
        [Authorize]
        [HttpPost("edit"), ActionName("Update")]
        public async Task<JsonResult> Edit([FromBody] RestaurantInfo restaurantInfo)
        {

            string emailAddress = HttpContext.User.Identity.Name;
            
            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            if (RestaurantNameExists(restaurantInfo.Name, emailAddress))
            {
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Restaurant name " + restaurantInfo.Name + " already exists");
            }
            else if (RestaurantEmailAddressExists(restaurantInfo.EmailAddress, emailAddress))
            {
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Restaurant email address " + restaurantInfo.EmailAddress + " already exists");
            }

            // set fields
            restaurant.Name = restaurantInfo.Name;
            restaurant.EmailAddress = restaurantInfo.EmailAddress;
            restaurant.Location = restaurantInfo.Location;
            restaurant.PhoneNumber = restaurantInfo.PhoneNumber;
            restaurant.HoursOpened = restaurantInfo.HoursOpened;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.Id))
                    {
                        return new JsonResult("");
                    } else
                    {
                        throw;
                    }
                }
                HttpContext.Response.StatusCode = 200;
              
            }

            return new JsonResult("Restaurant data successfully updated.");
        }

        // GET: Restaurant/Delete/5
        [Authorize]
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurant/Delete/5
        [Authorize]
        [HttpPost("delete/{id}"), ActionName("Delete")]  
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var restaurant = await _context.Restaurant.FindAsync(id);
            _context.Restaurant.Remove(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(long id)
        {
            return _context.Restaurant.Any(e => e.Id == id);
        }
        private bool RestaurantNameExists(string name, string emailAddress)
        {
            var restaurant = _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefault();

            if (name.Equals(restaurant.Name))
            {
                return false;
            }

            return _context.Restaurant.Any(rest => rest.Name.Equals(name));
        }
        private bool RestaurantEmailAddressExists(string newEmailAddress, string emailAddress)
        {
            var restaurant = _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefault();

            if (newEmailAddress.Equals(restaurant.EmailAddress))
            {
                return false;
            }

            return _context.Restaurant.Any(rest => rest.EmailAddress.Equals(newEmailAddress));
        }
    }
}
