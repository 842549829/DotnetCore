using System;
using System.Collections.Generic;
using DotnetCore.Infrastructure.RepositoryFramework;
using DotnetCore.Model.DB;
using DotnetCore.Model.Transfer;

namespace DotnetCore.IRepository
{
    /// <summary>
    /// 角色仓储接口
    /// </summary>
    public interface IRoleRepository : IRepository<Guid, MRole>
    {
        /// <summary>
        /// 角色分页查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>结果</returns>
        IEnumerable<MRole> QueryRolesByPaging(TRoleCondition condition);
    }
}