using DotnetCore.Code.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DotnetCode.Controller.Base.Filters
{
    /// <summary>
    /// 过滤器公用方法
    /// </summary>
    public class CommonFilters
    {
        /// <summary>
        /// 未登录
        /// </summary>
        /// <param name="context">context</param>
        public static void ProcessingRequireLogon(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            if (request != null && request.IsAjaxRequest())
            {
                var message = new
                {
                    Type = "RequireLogon",
                    Result = GetLoginUrl()
                };
                context.Result = new JsonResult(message);
            }
            else
            {
                context.Result = new RedirectResult(GetLoginUrl());
            }
        }

        /// <summary>
        /// 没有权限
        /// </summary>
        /// <param name="filterContext">当前上下文</param>
        public static void ProcessingUnauthorized(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            if (request != null && request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult(new { Type = "Unauthorized" });
            }
            else
            {
                filterContext.Result = new ViewResult { ViewName = "WithoutPermission", ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { { "message", "无权访问菜单" } } };
            }
        }

        /// <summary>
        /// 处理错误
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="message">message</param>
        public static void ProcessingException(ActionExecutingContext context, string message)
        {
            var request = context.HttpContext.Request;
            if (request != null && request.IsAjaxRequest())
            {
                var rel = new
                {
                    Type = "ExceptionPermission",
                    Result = message
                };
                context.Result = new JsonResult(rel);
            }
            else
            {
                context.Result = new ViewResult
                {
                    ViewName = "ExceptionPermission",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { { "message", message } }
                };
            }
        }

        /// <summary>
        /// 跳转到登录页面
        /// </summary>
        /// <returns>url</returns>
        public static string GetLoginUrl()
        {
            return "/Unauthorized/Login";
        }
    }
}