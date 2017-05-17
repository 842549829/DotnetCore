using DotnetCode.Controller.Base;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCore.Controller.Account
{
    /// <summary>
    /// 登录之前
    /// </summary>
    public class UnauthorizedController : Microsoft.AspNetCore.Mvc.Controller
    {
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns>视图</returns>
        public IActionResult Login()
        {
            return this.View();
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="userName">登录信息</param>
        /// <param name="password">登录密码</param>
        /// <param name="validateCode">验证码</param>
        /// <returns>结果</returns>
        [AcceptVerbs("POST")]
        public IActionResult Login(string userName, string password, string validateCode)
        {
            var result = LogonUtility.Logon(userName, password, validateCode);
            return Json(result);
        }

        /// <summary>
        /// 注册页面
        /// </summary>
        /// <returns>视图</returns>
        public IActionResult Register()
        {
            return this.View();
        }

        /// <summary>
        /// 注册方法
        /// </summary>
        /// <param name="registerAccount">注册信息</param>
        /// <returns>注册结果</returns>
        [AcceptVerbs("POST")]
        public IActionResult Register(dynamic registerAccount)
        {
            return Json(null);
        }

        /// <summary>
        /// 获取验证码方法
        /// </summary>
        /// <returns>验证码</returns>
        public IActionResult GetValidateCode()
        {
            var code = LogonUtility.GenerateValidateCode();
            return File(code, @"image/jpeg");
        }

        /// <summary>
        /// 无权访问
        /// </summary>
        /// <param name="message">显示消息</param>
        /// <returns>视图</returns>
        public IActionResult WithoutPermission(string message = "")
        {
            object data = message;
            return this.View(data);
        }

        /// <summary>
        /// 程序异常
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <returns>视图</returns>
        public IActionResult ExceptionPermission(string message = "")
        {
            object data = message;
            return this.View(data);
        }
    }
}