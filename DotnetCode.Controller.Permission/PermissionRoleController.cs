using System;
using System.Collections.Generic;
using DotnetCode.Controller.Base;
using DotnetCore.Model.Transfer;
using DotnetCore.Service;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCode.Controller.Permission
{
    /// <summary>
    /// PermissionRoleController
    /// </summary>
    public class PermissionRoleController : BaseController
    {
        /// <summary>
        /// 权限角色
        /// </summary>
        /// <param name="accountId">用户Id</param>
        /// <param name="accountName">用户名</param>
        /// <returns>视图</returns>
        public IActionResult PermissionRoleList(Guid accountId, string accountName)
        {
            ViewBag.AccountId = accountId;
            ViewBag.AccountName = accountName + "(角色设置)";
            return this.View();
        }

        /// <summary>
        /// 查询可用角色Id
        /// </summary>
        /// <returns>用户Id</returns>
        public IActionResult QueryRoleIds([FromQuery]Guid accountId)
        {
            var data = PermissionService.QueryMenuIds(accountId);
            return MyJson(data);
        }

        /// <summary>
        /// 保存权限角色
        /// </summary>
        /// <param name="model">用户</param>
        /// <returns>结果</returns>
        [HttpPost]
        public IActionResult SavePermissionRole([FromBody]PermissionModel model)
        {
            var result = PermissionService.SavePermissionMenu(model.RoleId, model.MenuIds, null);
            return MyJson(result);
        }
    }
}