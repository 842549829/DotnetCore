using System;
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
            var data = RoleService.QueryRolesByCompanyId();
            return this.View(data);
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

        /// <summary>
        /// 保存用户角色关系
        /// </summary>
        /// <param name="model">用户</param>
        /// <returns>结果</returns>
        [HttpPost]
        public IActionResult SaveAccountRole([FromBody] AccountRoleModel model)
        {
            var result = PermissionService.SavePermissionRole(model.AccountId, model.Roles, null);
            return MyJson(result);
        }
    }
}