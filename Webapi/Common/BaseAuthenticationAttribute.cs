using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security;

namespace WebApi.Common
{
    public class BaseAuthenticationAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            bool isRequire = WebConfigurationManager.AppSettings["IsRequire"].ToLower() == "true";
            if (isRequire)
            {
                //todo:身份验证
                if (actionContext.Request.Headers.Authorization != null)//带票据信息
                {
                    var ticket = actionContext.Request.Headers.Authorization.Parameter;
                    if (!UserValidate.ValidateUserTicket(ticket))
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    }
                }
                else//没有票据，判断匿名
                {
                    var attr =
                        actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>()
                            .OfType<AllowAnonymousAttribute>();
                    bool isanoymous = attr.Any(a => a is AllowAnonymousAttribute);
                    if (!isanoymous)
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    }
                }
            }
            base.OnActionExecuting(actionContext);
        }

       
    }
}