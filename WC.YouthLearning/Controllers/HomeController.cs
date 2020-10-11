using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WC.YouthLearning.Models;

namespace WC.YouthLearning.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db;
        public HomeController(DataContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
         string name=db.student.First().name;

        ViewBag.Name = name;
         return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}
