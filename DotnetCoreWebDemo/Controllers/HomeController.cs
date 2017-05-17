using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DotnetCoreWebDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            this.HttpContext.Session.Set("Key", "xx");
            var d = this.HttpContext.Session.Get<string>("Key");

            DotnetCoreWebDemo.HttpContext.Current.Session.SetString("Key", "xx");
            var se = DotnetCoreWebDemo.HttpContext.Current.Session.GetString("Key");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
