using System;
using System.Data;
using DotnetCore.Infrastructure.EntityFactoryFramework;
using DotnetCore.Model.DB;

namespace DotnetCore.Repository.Factory
{
    public class RoleUserRelationshipFactory : IEntityFactory<MRoleUserRelationship>
    {
        /// <summary>
        /// BuildEntity
        /// </summary>
        /// <param name="reader">reader</param>
        /// <returns>结果</returns>
        public MRoleUserRelationship BuildEntity(IDataReader reader)
        {
            return new MRoleUserRelationship
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                AccountId = Guid.Parse(reader["AccountId"].ToString()),
                RoleId = Guid.Parse(reader["RoleId"].ToString())
            };
        }
    }
}