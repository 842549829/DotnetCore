using DotnetCore.Code.Code;

namespace DotnetCore.Model.Transfer
{
    /// <summary>
    /// 角色查询条件
    /// </summary>
    public class TRoleCondition
    {
        /// <summary>
        /// 分页信息
        /// </summary>
        public Paging Paging { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string RoleDescription { get; set; }
    }
}