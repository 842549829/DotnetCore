﻿using System;
using System.Collections.Generic;
using DotnetCode.Controller.Base;
using DotnetCore.Model.Transfer;
using DotnetCore.Service;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCode.Controller.Permission
{
    /// <summary>
    /// 权限菜单
    /// </summary>
    public class PermissionMenuController : BaseController
    {
        /// <summary>
        /// 权限菜单
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="roleName">角色名称</param>
        /// <returns>视图</returns>
        public IActionResult PermissionMenuList(Guid roleId, string roleName)
        {
            ViewBag.RoleName = roleName + "(权限设置)";
            return this.View(roleId);
        }

        /// <summary>
        /// 查询可用菜单Id
        /// </summary>
        /// <returns>角色Id</returns>
        [HttpPost]
        public IActionResult QueryMenuIds([FromQuery]Guid roleId)
        {
            var data = PermissionService.QueryMenuIds(roleId);
            return MyJson(data);
        }

        /// <summary>
        /// 保存权限菜单
        /// </summary>
        /// <param name="model">用户</param>
        /// <returns>结果</returns>
        [HttpPost]
        public IActionResult SavePermissionMenu([FromBody]PermissionModel model)
        {
            var result = PermissionService.SavePermissionMenu(model.RoleId, model.MenuIds, null);
            return MyJson(result);
        }
    }
}