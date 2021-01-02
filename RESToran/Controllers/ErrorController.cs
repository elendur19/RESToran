using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESToran.Controllers
{
    public class ErrorController : Controller
    {
        // return 401 error view
        [HttpGet("/StatusCode/code=401")]
        public async Task<IActionResult> Index(int code)
        {
            return View();
        }
    }
}
