using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;

namespace DotnetCore.Code.Mvc
{
    /// <summary>
    /// JObjectModelBinderProvider
    /// </summary>
    public class JObjectModelBinderProvider : IModelBinderProvider
    {
        /// <summary>
        /// GetBinder
        /// </summary>
        /// <param name="context">context</param>
        /// <returns></returns>
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.Metadata.ModelType == typeof(JObject))//同时支Body持数据JObject，和Form键值对
            {
                return new JObjectModelBinder(context.Metadata.ModelType);
            }
            if (context.Metadata.ModelType == typeof(JArray))//Jarray支持
            {
                return new JObjectModelBinder(context.Metadata.ModelType);
            }
            return null;
        }
    }
}