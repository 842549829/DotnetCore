using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DotnetCode.Controller.Base.Filters
{
    /// <summary>
    /// 自定义视图规则
    /// </summary>
    public class CustomViewLocationExpander : IViewLocationExpander
    {
        /// <summary>
        /// PopulateValues
        /// </summary>
        /// <param name="context">context</param>
        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }

        /// <summary>
        /// ExpandViewLocations
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="viewLocations">viewLocations</param>
        /// <returns>视图规则</returns>
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            var views = new List<string>
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Account/{1}/{0}.cshtml",
                "~/Views/Permission/{1}/{0}.cshtml",
                "~/Views/SwfupLoad/{1}/{0}.cshtml"
            };
            return views;
        }
    }
}