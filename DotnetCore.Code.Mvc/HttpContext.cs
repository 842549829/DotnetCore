using Microsoft.AspNetCore.Http;

namespace DotnetCore.Code.Mvc
{
    /// <summary>
    /// 当前上下文
    /// </summary>
    public static class HttpContext
    {
        /// <summary>
        /// IHttpContextAccessor
        /// </summary>
        private static IHttpContextAccessor accessor;

        /// <summary>
        /// Current
        /// </summary>
        public static Microsoft.AspNetCore.Http.HttpContext Current => accessor.HttpContext;

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="httpContextAccessor">httpContextAccessor</param>
        internal static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            accessor = httpContextAccessor;
        }
    }
}