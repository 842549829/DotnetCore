using System.Threading.Tasks;
using DotnetCode.Controller.Base;
using DotnetCore.Model.Transfer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
        /// <param name="model">登录信息</param>
        /// <returns>结果</returns>
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel model)
        {
            var result = LogonUtility.Logon(model);
            return Json(result, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver()
            });
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