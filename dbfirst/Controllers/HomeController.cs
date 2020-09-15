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

       
       
        public IActionResult GetInfo(DateTime? start, DateTime? end, int? id)
        {
            using (var context = new dbfirstContext())
            {
               // var data = context.Table1.Where(p => p.Date >= start && p.Date < end && p.Id==id).ToList();
                // data.ToList();
                if (id == null)
                {
                    var data2 = context.Table1.Where(p => p.Date >= start && p.Date < end).ToList();
                    return View(data2);
                }
                else
                {
                    var data3= context.Table1.Where(p => p.Date >= start && p.Date < end && p.Id==id).ToList();
                    return View(data3);
                }
            }

        }

        public IActionResult GetInfoUsingId(DateTime? start, DateTime? end)
        {
            using (var context = new dbfirstContext())
            {
                var data = context.Table1.Where(p => p.Date >= start && p.Date < end && p.Id == 10).ToList();
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
