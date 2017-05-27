using System;
using System.Collections.Generic;

namespace DotnetCore.Model.Transfer
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public class AccountRoleModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public List<Guid> Roles { get; set; }
    }
}