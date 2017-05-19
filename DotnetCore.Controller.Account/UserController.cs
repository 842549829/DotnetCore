using System;
using DotnetCode.Controller.Base;
using DotnetCore.Code.Code;
using DotnetCore.Model.Transfer;
using DotnetCore.Service;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCore.Controller.Account
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns>结果</returns>
        public IActionResult UserList()
        {
            return this.View();
        }

        /// <summary>
        /// 用户列表查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>结果</returns>
        [HttpPost]
        public IActionResult UserListVal([FromBody]TAccountCondition condition)
        {
            var data = AccountService.QueryAccountByPaging(condition);
            return MyJson(data);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="registerAccount">用户信息</param>
        /// <returns>结果</returns>
        [AcceptVerbs("POST")]
        public IActionResult AddUser(RegisterAccount registerAccount)
        {
            registerAccount.Password = "123456";
            registerAccount.PayPassword = "123456";
            var result = AccountService.AddUser(registerAccount, null);
            return MyJson(result);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="tAccount">用户信息</param>
        /// <returns>结果</returns>
        [AcceptVerbs("POST")]
        public IActionResult UpdateUser(TAccount tAccount)
        {
            var result = ValidateTAccount(tAccount);
            if (!result.IsSucceed)
            {
                return MyJson(result);
            }
            result = AccountService.UpdateUser(tAccount, null);
            return MyJson(result);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">用户信息</param>
        /// <returns>结果</returns>
        [AcceptVerbs("POST")]
        public IActionResult RemoveUser(Guid userId)
        {
            var result = AccountService.RemoveUser(userId, null);
            return MyJson(result);
        }

        /// <summary>
        /// 验证用户信息
        /// </summary>
        /// <param name="tAccount">用户信息</param>
        /// <returns>角色</returns>
        private static Result ValidateTAccount(TAccount tAccount)
        {
            throw new NotImplementedException();
        }
    }
}