using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WarehouseMVC_DAL.Models;

namespace WarehouseMVC.Infrastructure.Atributes
{
    public class AuthorizeManagerAttribute : AuthorizeAttribute
    {
        private UtilisateurRole? _RoleAccess { get; }
        public AuthorizeManagerAttribute()
        {
            _RoleAccess = null;
        }
        public AuthorizeManagerAttribute(UtilisateurRole roleAccess)
        {
            _RoleAccess = roleAccess;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SessionManager.Utilisateur == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary()
                    {
                        {"action", "login" },
                        {"controller", "Auth"}
                    });
            }
            else if (!(_RoleAccess?.HasFlag(SessionManager.Utilisateur.Role) ?? true))
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }
    }
}