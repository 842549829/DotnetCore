using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DotnetCore.Code.Encrypt
{
    /// <summary>
    /// Md5
    /// </summary>	
    public class Md5
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="source">数据</param>
        /// <returns>结果</returns>
        public static string Encrypt32(string source)
        {
            using (var md5 = MD5.Create())
            {
                var bytHash = md5.ComputeHash(Encoding.UTF8.GetBytes(source));
                return bytHash.Aggregate("", (current, t) => current + t.ToString("x").PadLeft(2, '0')).ToUpper();
            }
        }
       
        /// <summary>
        /// 加密16
        /// </summary>
        /// <param name="source">数据</param>
        /// <returns>密文</returns>
        public static string Encrypt16(string source)
        {
            using (var md5 = MD5.Create())
            {
                string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(source)), 4, 8);
                t2 = t2.Replace("-", "");
                return t2.ToUpper();
            }
        }
    }
}