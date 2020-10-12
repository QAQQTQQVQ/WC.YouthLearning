using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WC.YouthLearning.BLL;

namespace WC.YouthLearning.Controllers
{
    public class UploadImage : Controller
    {
        private IStudentBll studentBll;
        public UploadImage(IStudentBll _studentBll)
        {
            studentBll = _studentBll;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string name,string myimg)
        {
            var stu = studentBll.GetEntities(u => u.name == name).FirstOrDefault();
            if(stu!=null)
            {
                Common.SaveImage.ByStringToSave(name, myimg);
                return Json("提交成功");
            }
            else
            {
                return Json("未找到该用户");
            }

        }
    }
}
