using System;
using System.Data;
using DotnetCore.Infrastructure.EntityFactoryFramework;
using DotnetCore.Model.DB;

namespace DotnetCore.Repository.Factory
{
    /// <summary>
    /// 角色仓储工作
    /// </summary>
    public class RoleFactory : IEntityFactory<MRole>
    {
        /// <summary>
        /// 创建角色信息
        /// </summary>
        /// <param name="reader">IDataReader</param>
        /// <returns>角色信息</returns>
        public MRole BuildEntity(IDataReader reader)
        {
            var mRole = new MRole
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                RoleName = reader["RoleName"].ToString(),
                RoleDescription = reader["RoleDescription"].ToString()
            };
            return mRole;
        }
    }
}