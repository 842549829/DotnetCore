using System.Data;
using DotnetCore.Infrastructure.EntityFactoryFramework;
using DotnetCore.Model.DB;

namespace DotnetCore.Repository.Factory
{
    /// <summary>
    /// 注册验证码仓储工厂
    /// </summary>
    public class VerificationCodeFactory : IEntityFactory<MVerificationCode>
    {
        /// <summary>
        /// 创建注册验证码
        /// </summary>
        /// <param name="reader">IDataReader</param>
        /// <returns>注册验证码</returns>
        public MVerificationCode BuildEntity(IDataReader reader)
        {
            return null;
        }
    }
}