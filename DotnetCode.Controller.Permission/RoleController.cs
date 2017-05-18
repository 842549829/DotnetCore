using System;
using System.Collections.Generic;
using DotnetCode.Controller.Base;
using DotnetCore.Code.Code;
using DotnetCore.Model.Transfer;
using DotnetCore.Service;
using Microsoft.AspNetCore.Mvc;
using Notify.Controller.Base.Filters;

namespace DotnetCode.Controller.Permission
{
    /// <summary>
    /// 角色控制器
    /// </summary>
    public class RoleController : BaseController
    {
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns>视图</returns>
        [OperatingAuthorize]
        public IActionResult RoleList(TRoleCondition condition)
        {
            if (condition != null)
            {
                //IEnumerable<TRole> data = RoleService.QueryRolesByPagings(condition);
                //PagedList<TRole> pageList = new PagedList<TRole>(data, condition.PageIndex, condition.PageSize, condition.RowsCount);
                //ViewModel<TRoleCondition, PagedList<TRole>> result = new ViewModel<TRoleCondition, PagedList<TRole>>
                //{
                //    Condition = condition,
                //    Data = pageList
                //};
                return this.View(result);
            }
            else
            {
                return this.View();
            }
        }

        /// <summary>
        /// 角色列表查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>结果</returns>
        [HttpPost]
        public IActionResult RoleListVal([FromBody]TRoleCondition condition)
        {
            var data = RoleService.QueryRolesByPaging(condition);
            return MyJson(data);
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="tRole">角色信息</param>
        /// <returns>结果</returns>
        [HttpPost]
        public IActionResult AddRole([FromBody]TRole tRole)
        {
            var result = ValidateTRole(tRole);
            if (!result.IsSucceed)
            {
                return MyJson(result);
            }
            result = RoleService.AddRole(tRole, null);
            return MyJson(result);
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="tRole">角色信息</param>
        /// <returns>结果</returns>
        [HttpPost]
        public IActionResult UpdateRole([FromBody]TRole tRole)
        {
            var result = ValidateTRole(tRole);
            if (!result.IsSucceed)
            {
                return MyJson(result);
            }
            result = RoleService.UpdateRole(tRole, null);
            return MyJson(result);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId">角色信息</param>
        /// <returns>结果</returns>
        [HttpPost]
        public IActionResult RemoveRole([FromBody]Guid roleId)
        {
            var result = RoleService.RemoveRole(roleId, null);
            return MyJson(result);
        }

        /// <summary>
        /// 验证角色信息
        /// </summary>
        /// <param name="tRole">角色信息</param>
        /// <returns>结果</returns>
        private static Result ValidateTRole(TRole tRole)
        {
            Result result = new Result();
            if (tRole == null)
            {
                result.Message = "角色信息为空";
                return result;
            }
            if (string.IsNullOrEmpty(tRole.RoleName))
            {
                result.Message = "角色名称为空";
                return result;
            }
            if (tRole.RoleName.Length > 50)
            {
                result.Message = "角色名称过长";
                return result;
            }
            if (string.IsNullOrEmpty(tRole.RoleDescription))
            {
                result.Message = "角色描述为空";
                return result;
            }
            if (tRole.RoleDescription.Length > 150)
            {
                result.Message = "角色描述过长";
                return result;
            }
            result.IsSucceed = true;
            return result;
        }
    }
}