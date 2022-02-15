using Ecommerce.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Filters
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        // Checking user is authorize or not
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool IsValidUser = true;
            // Authorization for valid member
            if (HttpContext.Current.Request.Cookies["UId"] == null || HttpContext.Current.Request.Cookies["UId"]==null)
                IsValidUser = false;

            if (IsValidUser)
            {
                // Authorization for valid role
                if (!string.IsNullOrEmpty(Roles))
                {
                    string privilegeLevels = string.Join("", EncryptDecrypt.Decrypt(HttpContext.Current.Request.Cookies["Role"].Value));
                    if (Roles.Contains(privilegeLevels))
                        IsValidUser = true;
                    else
                        IsValidUser = false;
                }
            }
            return IsValidUser;
        }

        // Based on Authorization result, redirct user to specific page
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary 
                        {
                            { "action", "Index" },
                            { "controller", "Account" },                           
                            {"returnUrl",filterContext.HttpContext.Request.Url.PathAndQuery}
                            //,{"returnUrl1",filterContext.HttpContext.Request.Url.PathAndQuery}
                        });            
        }
    }
}