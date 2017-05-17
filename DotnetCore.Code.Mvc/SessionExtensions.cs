using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DotnetCore.Code.Mvc
{
    /// <summary>
    /// Session扩展类
    /// </summary>
    public static class SessionExtensions
    {
        /// <summary>
        /// 设置Session
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="session">session</param>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// 获取Session
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="session">session</param>
        /// <param name="key">key</param>
        /// <returns>T</returns>
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject<T>(value);
        }
    }
}