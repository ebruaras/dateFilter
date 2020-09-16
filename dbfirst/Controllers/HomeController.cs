using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dbfirst.Models;
using PagedList.Core;

namespace dbfirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Index(int page = 1,int pageSize=5)
        {
            using (var context = new dbfirstContext())
            {
                var people = context.Table1.ToList();
                PagedList<Table1> peopleList = new PagedList<Table1>(context.Table1, page, pageSize);
                return View(peopleList);

            }
        }

       
     
        public IActionResult GetInfo(DateTime? start, DateTime? end, int? id, int page = 1, int pageSize = 5)
        {
            using (var context = new dbfirstContext())
            {
               // var data = context.Table1.Where(p => p.Date >= start && p.Date < end && p.Id==id).ToList();
                // data.ToList();
                if (id == null)
                {
                    var data2 = context.Table1.Where(p => p.Date >= start && p.Date < end);
                    PagedList<Table1> people = new PagedList<Table1>(data2, page, pageSize);
                    return View(people);
                }
                else
                {
                    var data3= context.Table1.Where(p => p.Date >= start && p.Date < end && p.Id==id);
                    PagedList<Table1> people2 = new PagedList<Table1>(data3, page, pageSize);
                    return View(people2);
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
