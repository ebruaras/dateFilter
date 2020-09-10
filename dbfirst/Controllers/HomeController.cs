using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dbfirst.Models;

namespace dbfirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

      

        public IActionResult Index()
        {
            using (var context = new dbfirstContext())
            {
                var people = context.Table1.ToList();
                return View(people);

            }
        }

       
       
        public IActionResult GetInfo(string start, string end)
        {
            using (var context = new dbfirstContext())
            {
                DateTime startdate = Convert.ToDateTime(start);
                DateTime enddate = Convert.ToDateTime(end);

                var data = context.Table1.Where(p => p.Date >= startdate && p.Date < enddate).ToList();
                //data.ToList();
                return View(data);
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
