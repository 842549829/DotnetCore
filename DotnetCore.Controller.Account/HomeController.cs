﻿using DotnetCode.Controller.Base;
using DotnetCore.Code.Code;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCore.Controller.Account
{
    /// <summary>
    /// Home
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// 登录首页
        /// </summary>
        /// <returns>视图</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// 登录首页
        /// </summary>
        /// <returns>视图</returns>
        public IActionResult Default()
        {
            return this.View();
        }

        /// <summary>
        /// QueryMenu
        /// </summary>
        /// <returns>ActionResult</returns>
        [AcceptVerbs("POST")]
        public IActionResult QueryMenu()
        {
            var data = EsayUIMenu;
            return Json(data);
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Logoff()
        {
            LogonUtility.Logoff();
            var result = new Result { IsSucceed = true };
            return Json(result);
        }
    }
}