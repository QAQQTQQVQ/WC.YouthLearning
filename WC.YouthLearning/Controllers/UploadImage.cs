using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WC.YouthLearning.Controllers
{
    public class UploadImage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string myimg)
        {
            Common.SaveImage.ByStringToSave(myimg);
            


            return View(model: myimg);
            return View();
        }
    }
}
