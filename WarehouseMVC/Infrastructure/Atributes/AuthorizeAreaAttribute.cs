using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WarehouseMVC.Infrastructure.Atributes
{
    public class AuthorizeAreaAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase HttpContext)
        {
            RouteData route = HttpContext.Request.RequestContext.RouteData;

            string area = route.DataTokens["Area"]?.ToString();
            if (area != null)
            {
                if (area == "Admin")
                {
                    return SessionManager.IsAdmin;
                }
                // Other Area
            }

            return true;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (SessionManager.Utilisateur != null)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}