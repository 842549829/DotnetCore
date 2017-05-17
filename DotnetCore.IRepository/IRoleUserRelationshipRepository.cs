using System;
using DotnetCore.Infrastructure.RepositoryFramework;
using DotnetCore.Model.DB;

namespace DotnetCore.IRepository
{
    /// <summary>
    /// 用户角色关系仓储接口
    /// </summary>
    public interface IRoleUserRelationshipRepository : IAddsRepository<MRoleUserRelationship>, IRepository<Guid, MRoleUserRelationship>
    {
        /// <summary>
        /// 根据用户Id删除
        /// </summary>
        /// <param name="accountId">用户Id</param>
        void RemoveByAccountId(Guid accountId);
    }
}
