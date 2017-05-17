namespace DotnetCore.Service
{
    /// <summary>
    /// 数据工厂
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// 数据工厂(当前上下文)
        /// </summary>
        public static IDbFactory.IDbFactory DbContext => null; //DbCommon.Repositroies.Factory.GetFactory<IDbFactory.IDbFactory>();
    }
}