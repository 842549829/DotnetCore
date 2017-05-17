using Microsoft.AspNetCore.Http;
using System;

namespace DotnetCore.Code.Mvc
{
    /// <summary>
    /// RequestExtensions
    /// </summary>
    public static class RequestExtensions
    {
        /// <summary>
        /// 是否是ajax请求
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>result</returns>
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            if (request.Headers != null)
            {
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            }
            return false;
        }
    }
}