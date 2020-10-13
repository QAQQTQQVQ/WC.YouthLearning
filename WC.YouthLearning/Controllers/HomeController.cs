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
        public HomeController(IStudentBll _studentBll, IAdminBll _adminBll)
        {
            studentBll = _studentBll;
            adminBll = _adminBll;
        }
        public async Task<IActionResult> Index()//展示全部数据
        {
            var students = studentBll.GetEntities(n => n.id > 0).ToListAsync();
            return View(await students);
        }
        public async Task<IActionResult> Login(string uname, string pwd)//管理员进行登入
        {
            var admin = adminBll.GetEntities(n => n.uname == uname).FirstOrDefaultAsync();
            admin ad = await admin;
            if (ad == null)
            {
                return Content("<script>alert('用户不存在！');window.location.href='/Home/Index';</script>", "text/html", System.Text.Encoding.UTF8);
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
                    return Content("<script>alert('密码错误！');window.location.href='/Home/Index';</script>", "text/html", System.Text.Encoding.UTF8);
                }
            }
        }
        public async Task<IActionResult> Reset(int id)//重置某个学生提交数据
        {
            if (judge())
            {
                var student = await studentBll.GetEntities(n => n.id == id).FirstOrDefaultAsync();
                student.time = "";
                student.sub = 0;
                studentBll.Update(student);
                return Content("<script>alert('重置该学生成功');window.location.href='/Home/Index';</script>", "text/html", System.Text.Encoding.UTF8);
            }
            return non();
        }
        public async Task<IActionResult> ResetAll()//重置所有学生提交数据
        {
            if (judge())
            {
                var student = await studentBll.GetEntities(u => u.id > 0).ToListAsync();

                studentBll.UpdataList(student);
                return Content("<script>alert('重置所有学生成功');window.location.href='/Home/Index';</script>", "text/html", System.Text.Encoding.UTF8);
            }
            return non();
        }
        public IActionResult Exite()//验证cookies是否存在
        {
            string name;
            HttpContext.Request.Cookies.TryGetValue("uname", out name);
            if (name != null)
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        public async Task<IActionResult> Show(int id)//进入展示页面
        {
            var student = await studentBll.GetEntities(n => n.id == id).FirstOrDefaultAsync();
            return View(student);
        }
        public async Task<IActionResult> Vip(int id)
        {
            if (judge())
            {
                var student = await studentBll.GetEntities(n => n.id == id).FirstOrDefaultAsync();
                student.time = "VIP用户";
                student.sub = 1;
                studentBll.Update(student);
                return Content("<script>alert('设置VIP成功');window.location.href='/Home/Index';</script>", "text/html", System.Text.Encoding.UTF8);
            }
            return non();
        }
        public IActionResult OutLogin()//退出登入
        {
            HttpContext.Response.Cookies.Delete("uname");
            return Content("<script>alert('成功退出');window.location.href='/Home/Index';</script>", "text/html", System.Text.Encoding.UTF8);
        }
        public IActionResult non()//无权跳转到主页
        {
            return Content("<script>alert('你无权这么做');window.location.href='/Home/Index';</script>", "text/html", System.Text.Encoding.UTF8);
        }

        public bool judge()//判断是否登入
        {
            string name;
            HttpContext.Request.Cookies.TryGetValue("uname", out name);
            if (name != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<IActionResult> SubTotal()//返回提交总数
        {
            var students = await studentBll.GetEntities(n => n.sub==1).ToListAsync();
            return Content(students.Count().ToString());
        }
        public async Task<IActionResult> NotSubTotal()//返回未提交总数
        {
            var students = await studentBll.GetEntities(n => n.sub == 0).ToListAsync();
            return Content(students.Count().ToString());
        }
    }
}
