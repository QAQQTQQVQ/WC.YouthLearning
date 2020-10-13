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
        public IActionResult CreateZip()
        {
            string name;
            HttpContext.Request.Cookies.TryGetValue("uname", out name);
            if (name != null)
            {
                Common.SaveImage.CreateZip();
                return Content("<script>alert('文件压缩完成！即将下载');window.location.href='../StudentImage.zip';</script>", "text/html", System.Text.Encoding.UTF8);
            }
            else
            {
                return Content("<script>alert('你无权这么做！');window.location.href='../Home/Index';</script>", "text/html", System.Text.Encoding.UTF8);
            }
           
        }
        public IActionResult DeleteAll()
        {
            string name;
            HttpContext.Request.Cookies.TryGetValue("uname", out name);
            if (name != null)
            {
                if(Common.SaveImage.DelectAll())
                {
                    return Content("<script>alert('文件删除完成');window.location.href='../Home/Index';</script>", "text/html", System.Text.Encoding.UTF8);
                }
                else
                {
                    return Content("<script>alert('文件删除异常，请联系赖师傅');window.location.href='../Home/Index';</script>", "text/html", System.Text.Encoding.UTF8);
                }
            }
            else
            {
                return Content("<script>alert('管理员未登录，请检查是否拥有权限');window.location.href='../Home/Index';</script>", "text/html", System.Text.Encoding.UTF8);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Index(string name,string myimg)
        {
            var stu =await studentBll.GetEntities(u => u.name == name).FirstOrDefaultAsync();
            if(myimg==null)
                return Content("<script>alert('图片未提交！');window.location.href='../Home/Index';</script>","text/html", System.Text.Encoding.UTF8);
            if (stu!=null)
            {
                stu.sub = 1;
                stu.time = DateTime.Now.ToString();
                Common.SaveImage.ByStringToSave(name, myimg);
                studentBll.Update(stu);
                return Content("<script>alert('提交成功！安心睡吧！');window.location.href='../Home/Index';</script>", "text/html", System.Text.Encoding.UTF8);
            }
            else
            {
                return Content("<script>alert('你确定是本班的？');window.location.href='../Home/Index';</script>", "text/html", System.Text.Encoding.UTF8);
            }

        }

    }
}
