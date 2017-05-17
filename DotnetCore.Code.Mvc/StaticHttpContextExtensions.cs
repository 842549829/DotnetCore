using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetCore.Code.Mvc
{
    /// <summary>
    /// HttpContext扩展类型
    /// </summary>
    public static class StaticHttpContextExtensions
    {
        /// <summary>
        /// AddHttpContextAccessor
        /// </summary>
        /// <param name="services">services</param>
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        /// <summary>
        /// UseStaticHttpContext
        /// </summary>
        /// <param name="app">app</param>
        /// <returns>IApplicationBuilder</returns>
        public static IApplicationBuilder UseStaticHttpContext(this IApplicationBuilder app)
        {
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            HttpContext.Configure(httpContextAccessor);
            return app;
        }
    }
}