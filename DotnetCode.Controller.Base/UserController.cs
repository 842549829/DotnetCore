using DotnetCore.Model.Transfer;
using DotnetCore.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DotnetCode.Controller.Base
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
        public IActionResult UserList(TAccountCondition condition)
        {
            if (condition != null)
            {
                //var data = AccountService.QueryAccountByPagings(condition);
                //PagedList<TAccount> pageList = new PagedList<TAccount>(data, condition.PageIndex, condition.PageSize, condition.RowsCount);
                //ViewModel<TAccountCondition, PagedList<TAccount>> result = new ViewModel<TAccountCondition, PagedList<TAccount>>
                //{
                //    Condition = condition,
                //    Data = pageList
                //};
                return this.View();
            }
            else
            {
                return this.View();
            }
        }

        /// <summary>
        /// 用户列表查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>结果</returns>
        [AcceptVerbs("POST")]
        public IActionResult UserListVal(TAccountCondition condition)
        {
            var data = AccountService.QueryAccountByPaging(condition);
            return Json(data);
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
            return Json(result);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="tAccount">用户信息</param>
        /// <returns>结果</returns>
        [AcceptVerbs("POST")]
        public IActionResult UpdateUser(TAccount tAccount)
        {
            var result = AccountService.UpdateUser(tAccount, null);
            return Json(result);
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
            return Json(result);
        }
    }
}
