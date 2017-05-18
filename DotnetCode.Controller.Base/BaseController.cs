using System;
using System.Collections.Generic;
using DotnetCode.Controller.Base.Filters;
using DotnetCore.Model.Transfer;
using DotnetCore.Service;
using DotnetCore.Code.Mvc;
using DotnetCore.Code.Constant;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DotnetCode.Controller.Base
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    [UserAuthorize]
    //[OperatingAuthorize]
    public class BaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public static TAccount LogonUser
        {
            get
            {
                var session = DotnetCore.Code.Mvc.HttpContext.Current.Session;
                if (session == null)
                {
                    return null;
                }
                var account = session.Get<TAccount>(Const.UserSessionKey);
                return account;
            }
        }

        /// <summary>
        /// 权限菜单
        /// </summary>
        public static IEnumerable<TMenu> Menu
        {
            get
            {
                var session = DotnetCore.Code.Mvc.HttpContext.Current.Session;
                if (session == null)
                {
                    return null;
                }
                var menu = session.Get<IEnumerable<TMenu>>(Const.MenuSessionKey);
                return menu;
            }
        }

        /// <summary>
        /// 权限菜单(EsayUI)
        /// </summary>
        public static IEnumerable<EsayUIMenu> EsayUIMenu
        {
            get
            {
                var session = DotnetCore.Code.Mvc.HttpContext.Current.Session;
                if (session == null)
                {
                    return null;
                }
                var menu = session.Get<IEnumerable<EsayUIMenu>>(Const.EsayUIMenuSessionKey);
                return menu;
            }
        }

        /// <summary>
        /// 登录状态
        /// </summary>
        public static bool Logoned => LogonUser != null && LogonUser.Id != Guid.Empty;

        /// <summary>
        /// 验证权限
        /// </summary>
        /// <param name="address">菜单地址</param>
        /// <returns>结果</returns>
        public static bool HasPermission(string address)
        {
            return MenuService.HasPermission(Menu, address);
        }

        /// <summary>
        /// 返回MyJson
        /// </summary>
        /// <param name="data">data</param>
        /// <returns>json</returns>
        public JsonResult MyJson(object data)
        {
            return Json(data, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver()
            });
        }
    }
}