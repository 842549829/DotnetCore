using Autofac;
using DotnetCore.MysqlDbFactory;

namespace DotnetCore.Domain
{
    /// <summary>
    /// 数据工厂
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// 数据工厂(当前上下文)
        /// </summary>
        public static IDbFactory.IDbFactory DbContext => GetIDbFactory();

        /// <summary>
        /// IContainer
        /// </summary>
        public static IContainer container = null;

        /// <summary>
        /// GetIDbFactory
        /// </summary>
        /// <returns>IDbFactory</returns>
        public static IDbFactory.IDbFactory GetIDbFactory()
        {
            if (container == null)
            {
                GetContainerBuilder();
            }
            if (container == null)
            {
                return null;
            }
            using (var scope = container.BeginLifetimeScope())
            {
                return scope.Resolve<IDbFactory.IDbFactory>();
            }
        }

        /// <summary>
        /// Create IContainer
        /// </summary>
        public static void GetContainerBuilder()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MysqlFactory>().As<IDbFactory.IDbFactory>();
            container = builder.Build();
        }
    }
}