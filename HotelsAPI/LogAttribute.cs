using HotelsAPI.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsAPI
{
    internal class LogAttribute : ResultFilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            JObject result = null;
            try
            {
                result = JObject.Parse(JsonConvert.SerializeObject(context.Result));
            }
            catch { }
            string request = context.HttpContext.Request.Method + " on " + context.HttpContext.Request.Path;
            string exception = string.Empty;
            string IPAddress = context.HttpContext.Connection.LocalIpAddress.ToString();
            if (context.Exception != null)
            {
                exception = context.Exception.Message;
            }
            JToken token = null;
            if (result != null)
                result.TryGetValue("Value", out token);
            string response = string.Empty;
            if (token != null)
                response = token.ToString();
            Log log = new Log()
            {
                IP = IPAddress,
                Request = request,
                Response = response,
                Exception = exception,
                Time = DateTime.Now,
                Comment = null
            };
            Logger.Instance.Log(log);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
