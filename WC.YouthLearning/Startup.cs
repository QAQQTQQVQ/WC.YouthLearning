using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WC.YouthLearning.BLL;
using WC.YouthLearning.DAL;
using WC.YouthLearning.Models;

namespace WC.YouthLearning
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            string connection = "server = 49.235.212.122; Database = jift; UId = sa; PWD = qz52013142020.; ";
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connection);
            });
            services.AddScoped(typeof(BaseDal<>));
            services.AddScoped(typeof(BaseBll<>));
            services.AddScoped<IStudentBll,StudentBll>();
            services.AddScoped<IAdminBll, AdminBll>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option =>
               {
                   option.LoginPath = new PathString("/Login"); //设置登陆失败或者未登录授权的情况下，直接跳转的路径这里
                                                                //设置cookie只读情况
                    option.Cookie.HttpOnly = true;
                    //cookie过期时间
                    //option.Cookie.Expiration = TimeSpan.FromSeconds(10);//此属性已经过期忽略，使用下面的设置
                    option.ExpireTimeSpan = new TimeSpan(1, 0, 0);//默认14天
                });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
