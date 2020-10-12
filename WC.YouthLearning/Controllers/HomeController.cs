using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WC.YouthLearning.BLL;
using WC.YouthLearning.Models;

namespace WC.YouthLearning.Controllers
{
    public class HomeController : Controller
    {
        private IStudentBll studentBll;
        public HomeController(IStudentBll _studentBll)
        {
            studentBll = _studentBll;
        }
        public async Task<IActionResult> Index()
        {
         var students = studentBll.GetEntities(n => n.id > 0).ToListAsync();
         return View(await students);
        }
    }
}
