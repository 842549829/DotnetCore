using DotnetCode.Controller.Base.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using DotnetCore.Code.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DotnetCoreWeb
{
    public class Startup
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services">services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // 注册HttpContext
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Session 是基于 IDistributedCache 构建的，所以必须引用一种 IDistributedCache 的实现，ASP.NET Core 提供了多种 IDistributedCache 的实现（Redis、SQL Server、In-memory）
            // 注册Session
            services.AddDistributedMemoryCache();
            services.AddSession();

            // 注册视图规则
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new CustomViewLocationExpander());
            });

            // 注册MVC
            services.AddMvc();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">app</param>
        /// <param name="env">env</param>
        /// <param name="loggerFactory">loggerFactory</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 注册过滤器
            app.UseStaticFiles();

            // 注册HttpContext
            app.UseStaticHttpContext();

            // 注册Session 必须在 UseMvc 之前调用
            app.UseSession();

            // 注册路由
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}