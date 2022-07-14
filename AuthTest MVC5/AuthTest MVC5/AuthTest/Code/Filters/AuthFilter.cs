using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using AuthTest.Code.Json;

namespace AuthTest.Code.Filters
{
    public class AuthFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public AuthFilter()
        {
            Rule = JsonHelper.GetJsonObject();
        }

        public string  Rule { get; }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            try
            {
                string token = GetToken(filterContext);
                var result = new TokenService().GetResult(token, Rule);
                if (result.active == false)
                {
                    filterContext.Result = new JsonResult()
                    {
                        ContentType = "application/json",
                        Data = new { status = "unauthorized" },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                    return;
                }
                else {
                    filterContext.HttpContext.Items["authData"] = result;
                }
            }
            catch (AuthException authException)
            {
                filterContext.Result = authException.FilterContext.Result;
            }


        }

        private string GetToken(AuthenticationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Request.Headers["Authorization"])))
            {
                filterContext.Result = new JsonResult()
                {
                    ContentType = "application/json",
                    Data = new { status = "unauthorized" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                throw new AuthException(filterContext);
            }

            return Convert.ToString(filterContext.HttpContext.Request.Headers["Authorization"]).Split(' ')[1];
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                //filterContext.Result = new RedirectToRouteResult(
                //    new RouteValueDictionary {
                //    { "controller", "Account" },
                //    { "action", "Login" } });
            }
        }
    }
}