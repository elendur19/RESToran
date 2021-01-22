using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESToran.DataAccess;
using RESToran.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using RESToran.DataClasses;
using System.Collections.Generic;

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

        // GET: All Tables from one of the restaurants
        [Authorize]
        [HttpGet("Restaurant/all")]
        public async Task<JsonResult> AllTables()
        {

            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            List<TableInfo> tablesToReturn = new List<TableInfo>();


            List<Table> restaurantTables = await _context.Table
                                                    .Where(t => t.RestaurantId == restaurant.Id)
                                                    .ToListAsync();

            // add table to table representation model class
            foreach(Table table in restaurantTables)
            {
                TableInfo tableInfo = new TableInfo(table.Description, table.RestName_Number, table.NumberOfSeats);
                tablesToReturn.Add(tableInfo);
            }


            //ViewBag.Restaurant = restaurant;

            return new JsonResult(tablesToReturn);
        }

        // GET: Table info
        // FOR DESKTOP APP
        [Authorize]
        [HttpGet("Restaurant/info")]
        public async Task<JsonResult> Info(long? id)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            string tableNumber = Request.Headers["tableNumber"];

            string restName_TableNumber = restaurant.Name + " " + tableNumber;

            var table = await _context.Table
                .FirstOrDefaultAsync(t => t.RestName_Number.Equals(restName_TableNumber));

            if (table == null)
            {
                return new JsonResult("Table doesn't exist");
            }

            return new JsonResult(new TableInfo(table.Description, table.RestName_Number, table.NumberOfSeats));
        }

/*        // GET: Restaurant table informations
        [Authorize]
        [HttpGet("Restaurant/Create")]
        public IActionResult Create(long id)
        {
            return View();
        }*/

        // This method creates new restaurant table

        [Authorize]
        [HttpPost("Restaurant/create"), ActionName("Create")]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Create([FromBody] TableInfo tableInfo)
        {

            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            Table newTable = new Table();

            long NbrOfRestaurantTables = _context.Table
                                .Where(t => t.RestaurantId == restaurant.Id).Count();
            // set RestName with restaurant name and  number of tables in it +1
            int number = (int)NbrOfRestaurantTables + 1;
            string restName = restaurant.Name + " " + number.ToString();

            if (tableInfo.Description == null)
            {
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Table description must be given");
            }

            newTable.Description = tableInfo.Description;
            newTable.RestName_Number = restName;
            newTable.NumberOfSeats = tableInfo.NumberOfSeats;

            if (ModelState.IsValid)
            {
                newTable.RestaurantId = restaurant.Id;

                _context.Add(newTable);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(AllTables), new { id = id });
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Table successfully created");
        }

        // GET: Table info

        [Authorize]
        [HttpGet("Restaurant/edit")]
        public async Task<JsonResult> Edit(long? id)
        {

            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            string tableNumber = Request.Headers["tableNumber"];

            string restName_TableNumber = restaurant.Name + " " + tableNumber;

            var table = await _context.Table
                .FirstOrDefaultAsync(t => t.RestName_Number.Equals(restName_TableNumber));

            if (table == null)
            {
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Table not found");
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult(new TableInfo(table.Description, table.RestName_Number, table.NumberOfSeats));
        }

        // POST: Update Table info
        // FOR DESKTOP APP
        [Authorize]
        [HttpPost("Restaurant/edit"), ActionName("Update")]
        public async Task<IActionResult> Edit(long id, [FromBody] TableInfo tableInfo)
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            string tableNumber = Request.Headers["tableNumber"];

            string restName_TableNumber = restaurant.Name + " " + tableNumber;

            Table tableToUpdate = await _context.Table
                .FirstOrDefaultAsync(t => t.RestName_Number.Equals(restName_TableNumber));

            if (tableToUpdate == null)
            {
                return new JsonResult("Table doesn't exist");
            }

            if (tableInfo.Description == null)
            {
                HttpContext.Response.StatusCode = 400;
                return new JsonResult("Table description must be given");
            }

            tableToUpdate.Description = tableInfo.Description;
            tableToUpdate.NumberOfSeats = tableInfo.NumberOfSeats;

            if (ModelState.IsValid)
            {
                
                try
                {
                    _context.Update(tableToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableExists(tableToUpdate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
 
            }

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Table successfully updated");
        }

/*        // GET: api/Restaurant/{restId}/Table/Delete/{id}
        [Authorize]
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
        }*/

        // DELETE: delete table with id
        [Authorize]
        [HttpDelete("Restaurant/delete"), ActionName("Delete")] 
        public async Task<JsonResult> DeleteTable(long id)
        {

            string emailAddress = HttpContext.User.Identity.Name;

            var restaurant = await _context.Restaurant
                                        .Where(rest => rest.EmailAddress.Equals(emailAddress))
                                        .FirstOrDefaultAsync();

            string tableNumber = Request.Headers["tableNumber"];

            string restName_TableNumber = restaurant.Name + " " + tableNumber;

            Table tableToDelete = await _context.Table
                .FirstOrDefaultAsync(t => t.RestName_Number.Equals(restName_TableNumber));

            if (tableToDelete == null)
            {
                return new JsonResult("Table doesn't exist");
            }

            _context.Table.Remove(tableToDelete);
            await _context.SaveChangesAsync();

            HttpContext.Response.StatusCode = 200;
            return new JsonResult("Table successfully deleted");
        }

        private bool TableExists(long id)
        {
            return _context.Table.Any(e => e.Id == id);
        }
    }
}
