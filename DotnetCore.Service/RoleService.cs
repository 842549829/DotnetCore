﻿using System;
using System.Collections.Generic;
using DotnetCore.Code.Code;
using DotnetCore.Code.Constant;
using DotnetCore.Code.Write;
using DotnetCore.Domain;
using DotnetCore.Model.Transfer;
using DotnetCore.Domain.RoleDomain;

namespace DotnetCore.Service
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public class RoleService
    {
        /// <summary>
        /// 数据工厂(当前上下文)
        /// </summary>
        public static IDbFactory.IDbFactory DbContext = Factory.DbContext;

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="tRole">角色信息</param>
        /// <param name="operational">操作信息</param>
        /// <returns>结果</returns>
        public static Result AddRole(TRole tRole, Operational operational)
        {
            Result result = new Result();
            try
            {
                using (var roleRepository = DbContext.CreateIRoleRepository())
                {
                    if (tRole.Id == Guid.Empty)
                    {
                        tRole.Id = Guid.NewGuid();
                    }
                    var mRole = tRole.ToMRole();
                    roleRepository.Add(mRole);
                }

                result.IsSucceed = true;
                result.Message = "添加成功";

            }
            catch (Exception ex)
            {
                result.IsSucceed = false;
                result.Message = Const.ErrorMessage;
                LogService.WriteLog(ex, "添加角色");
            }
            return result;
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="tRole">角色信息</param>
        /// <param name="operational">操作信息</param>
        /// <returns>结果</returns>
        public static Result UpdateRole(TRole tRole, Operational operational)
        {
            Result result = new Result();
            try
            {
                using (var roleRepository = DbContext.CreateIRoleRepository())
                {
                    var mRole = tRole.ToMRole();
                    roleRepository.Update(mRole);
                }

                result.IsSucceed = true;
                result.Message = "修改成功";
            }
            catch (Exception ex)
            {
                result.IsSucceed = false;
                result.Message = Const.ErrorMessage;
                LogService.WriteLog(ex, "修改角色");
            }
            return result;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId">角色信息</param>
        /// <param name="operational">操作信息</param>
        /// <returns>结果</returns>
        public static Result RemoveRole(Guid roleId, Operational operational)
        {
            Result result = new Result();
            try
            {
                using (var roleRepository = DbContext.CreateIRoleRepository())
                {
                    var mRole = roleId.ToMRole();
                    roleRepository.Remove(mRole);
                }

                result.IsSucceed = true;
                result.Message = "删除成功";
            }
            catch (Exception ex)
            {
                result.IsSucceed = false;
                result.Message = Const.ErrorMessage;
                LogService.WriteLog(ex, "删除角色");
            }
            return result;
        }

        /// <summary>
        /// 角色分页查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>结果</returns>
        public static QueryResult<TRole> QueryRolesByPaging(TRoleCondition condition)
        {
            using (var roleRepository = DbContext.CreateIRoleRepository())
            {
                var data = roleRepository.QueryRolesByPaging(condition).ToTRole();
                QueryResult<TRole> roles = new QueryResult<TRole>
                {
                    Data = data,
                    Paging = condition.Paging
                };
                return roles;
            }
        }

        /// <summary>
        /// 角色分页查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>结果</returns>
        public static IEnumerable<TRole> QueryRolesByPagings(TRoleCondition condition)
        {
            using (var roleRepository = DbContext.CreateIRoleRepository())
            {
                var data = roleRepository.QueryRolesByPaging(condition).ToTRole();
                return data;
            }
        }

        /// <summary>
        /// 根据公司名称查询角色
        /// </summary>
        /// <returns>角色</returns>
        public static IEnumerable<TRole> QueryRolesByCompanyId()
        {
            using (var roleRepository = DbContext.CreateIRoleRepository())
            {
                var data = roleRepository.QueryRolesByCompanyId().ToTRole();
                return data;
            }
        }
    }
}