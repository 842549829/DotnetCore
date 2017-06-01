using Autofac;
using DotnetCore.Code.Utility;
using DotnetCore.MysqlDbFactory;
using DotnetCore.SqlServerDbFactory;
using Microsoft.Extensions.Configuration;

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
            IConfiguration configuration = Configuration.GetConfigurationRootByJson("config.json");
            var builder = new ContainerBuilder();
            switch (configuration["ProviderName"].ToLower())
            {
                case "mysql.data.mysqlclient":
                    builder.RegisterType<MysqlFactory>().As<IDbFactory.IDbFactory>();
                    break;
                case "oracle.data.oracleclient":
                    //conn = new OracleConnection(connectionSetting.ConnectionString);
                    break;
                case "access.data.accessclient":
                    //conn = new OleDbConnection(connectionSetting.ConnectionString);
                    break;
                default:
                    builder.RegisterType<SqlServerFactory>().As<IDbFactory.IDbFactory>();
                    break;
            }
            container = builder.Build();
        }
    }
}