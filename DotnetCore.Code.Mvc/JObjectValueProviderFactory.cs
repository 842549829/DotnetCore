using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;

namespace DotnetCore.Code.Mvc
{
    public class JObjectValueProviderFactory : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext controllerContext)
        {
            if (controllerContext == null) throw new ArgumentNullException("controllerContext");
            if (controllerContext.ActionContext.HttpContext.Request.ContentType == null) { return Task.CompletedTask; };

            if (!controllerContext.ActionContext.HttpContext.Request.ContentType.
                StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;//不是"application/json"类型不处理交给原有的
            }
            var bodyText = string.Empty;
            using (var reader = new StreamReader(controllerContext.ActionContext.HttpContext.Request.Body))
            {
                bodyText = reader.ReadToEnd().Trim();//取得Body
            }
            if (string.IsNullOrEmpty(bodyText)) { return Task.CompletedTask; }//为空不处理
            else
            {//添加JObject一ValueProviders以便处理值
                controllerContext.ValueProviders.Add(
                    new JObjectValueProvider(bodyText.EndsWith("]}") ?//是不是组
                        JArray.Parse(bodyText) as JContainer ://是Jarray
                        JObject.Parse(bodyText) as JContainer));// JObject
            }
            return Task.CompletedTask;
        }
    }
}
