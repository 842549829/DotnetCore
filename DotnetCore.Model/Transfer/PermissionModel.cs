using System;
using System.Collections.Generic;

namespace DotnetCore.Model.Transfer
{
    /// <summary>
    /// 角色model
    /// </summary>
    public class PermissionModel
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// 菜单Id
        /// </summary>
        public List<Guid> MenuIds { get; set; }
    }
}