﻿using System;
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
        private IAdminBll adminBll;
        public HomeController(IStudentBll _studentBll,IAdminBll _adminBll)
        {
            studentBll = _studentBll;
            adminBll = _adminBll;
        }
        public async Task<IActionResult> Index()//展示全部数据
        {
         var students = studentBll.GetEntities(n => n.id > 0).ToListAsync();
         return View(await students);
        }
        public async Task<IActionResult> Login(string uname,string pwd)//管理员进行登入
        {
            var admin = adminBll.GetEntities(n => n.uname==uname).FirstOrDefaultAsync();
             admin ad = await admin;
            if (ad == null)
            {
                return Content("<script>alert('用户不存在！');window.location.href='../Home/Index';</script>");
            }
            else
            {
                if (ad.pwd == pwd)
                {
                    HttpContext.Response.Cookies.Append("uname", uname);
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("<script>alert('密码错误！');window.location.href='../Home/Index';</script>");
                }
            }
            
        }
    }
}
