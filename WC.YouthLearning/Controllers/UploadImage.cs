using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index(string name,string myimg)
        {
            var stu =await studentBll.GetEntities(u => u.name == name).FirstOrDefaultAsync();
            if(myimg==null)
                return Content("<script>alert('图片未提交！');window.location.href='../Home/Index';</script>");
            if (stu!=null)
            {
                stu.sub = 1;
                stu.time = DateTime.Now.ToString();
                Common.SaveImage.ByStringToSave(name, myimg);
                studentBll.Update(stu);
                return Content("<script>alert('提交成功！安心睡吧！');window.location.href='../Home/Index';</script>");
            }
            else
            {
                return Content("<script>alert('你确定是本班的？');window.location.href='../Home/Index';</script>");
            }

        }

    }
}
