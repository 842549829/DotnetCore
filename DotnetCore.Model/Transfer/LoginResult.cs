using Dotnet.Code.Code;
using System.Collections.Generic;

namespace DotnetCore.Model.Transfer
{
    /// <summary>
    /// 登录结果
    /// </summary>
    public class LoginResult : Result
    {
        /// <summary>
        /// 菜单(页面菜单展示加载)
        /// </summary>
        public IEnumerable<EsayUIMenu> EsayUiMenu { get; set; }

        /// <summary>
        /// 菜单权限
        /// </summary>
        public IEnumerable<TMenu> Menu { get; set; }

        /// <summary>
        /// 登录账户信息
        /// </summary>
        public TAccount Account { get; set; }
    }
}