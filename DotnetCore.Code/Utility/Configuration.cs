using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Xml;

namespace DotnetCore.Code.Utility
{
    /// <summary>
    /// 配置信息
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// 获取配置文件对象
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static IConfigurationRoot GetConfigurationRootByJson(string path)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            IConfigurationSource configurationSource = new JsonConfigurationSource()
            {
                Path = path,
            };
            configurationBuilder.Add(configurationSource);
            return configurationBuilder.Build();
        }

        /// <summary>
        /// 获取配置文件对象
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static IConfigurationRoot GetConfigurationRootByXml(string path)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            IConfigurationSource configurationSource = new XmlConfigurationSource()
            {
                Path = path,
            };
            configurationBuilder.Add(configurationSource);
            return configurationBuilder.Build();
        }
    }
}