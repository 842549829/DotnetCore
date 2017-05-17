using DotnetCode.Controller.Base;
using DotnetCode.Controller.Base.Filters;
using DotnetCore.Code.Write;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;
using DotnetCore.Code.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace Notify.Controller.Base.Filters
{
    /// <summary>
    /// 用户是否登录筛选器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class UserAuthorizeAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 登录处理
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="next">next</param>
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                if (!BaseController.Logoned)
                {
                    CommonFilters.ProcessingRequireLogon(context);
                }
            }
            catch (Exception ex)
            {
                LogService.WriteLog(ex, "登录验证出错");
                CommonFilters.ProcessingException(context, "登录验证出错");
            }
            return base.OnActionExecutionAsync(context, next);
        }
    }
}