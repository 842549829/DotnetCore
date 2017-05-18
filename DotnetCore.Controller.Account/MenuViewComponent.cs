using System;
using System.Collections.Generic;
using System.Text;using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCore.Controller.Account
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("QueryTMenu");
        }
    }
}
