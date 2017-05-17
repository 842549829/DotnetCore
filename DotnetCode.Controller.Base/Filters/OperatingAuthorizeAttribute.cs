using DotnetCode.Controller.Base;
using DotnetCode.Controller.Base.Filters;
using DotnetCore.Code.Mvc;
using DotnetCore.Code.Write;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;

namespace Notify.Controller.Base.Filters
{
    /// <summary>
    /// 菜单权限
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class OperatingAuthorizeAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 控制器执行之前
        /// </summary>
        /// <param name="context">控制器执行上下文</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                string controllerName = context.RouteData.Values["controller"].ToString();
                string actionName = context.RouteData.Values["action"].ToString();

                // 验证权限
                if (!PermissionValidation(controllerName, actionName))
                {
                    CommonFilters.ProcessingUnauthorized(context);
                }
            }
            catch (Exception ex)
            {
                LogService.WriteLog(ex, "权限验证出错");
                CommonFilters.ProcessingException(context, "权限验证出错");
            }
        }

        /// <summary>
        /// 权限查询
        /// </summary>
        /// <param name="controller">controller</param>
        /// <param name="action">action</param>
        /// <returns>result</returns>
        public static bool PermissionValidation(string controller, string action)
        {
            var url = GetUrlMenu(controller, action);
            return BaseController.HasPermission(url);
        }

        /// <summary>
        /// 获取菜单URL
        /// </summary>
        /// <param name="controller">controller</param>
        /// <param name="action">action</param>
        /// <returns>菜单URL</returns>
        public static string GetUrlMenu(string controller, string action)
        {
            return $"/{controller}/{action}";
        }

        /// <summary>
        /// 验证权限
        /// </summary>
        /// <param name="action">action</param>
        /// <param name="controller">controller</param>
        /// <returns>结果</returns>
        public static bool IsAuthorization(string action, string controller)
        {
            return PermissionValidation(controller, action);
        }
    }
}