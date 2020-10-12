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
                return Content("<script>alert('提交成功！安心睡吧！');window.location.href='../Home/Index';</script>");
            }
            else
            {
                return Content("<script>alert('你确定是本班的？');window.location.href='../Home/Index';</script>");
            }

        }
    }
}
