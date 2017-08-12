using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Control_cuentas_maestro.seguridad;
using Control_cuentas_maestro.Models;
using System.Web.Routing;

namespace Control_cuentas_maestro.seguridad
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.username))
            {
                
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "home", action = "index" }));
               
            }
            else

            {
                modelo_cuentas mc = new modelo_cuentas();
                customPrincipal cp = new customPrincipal(mc.find(SessionPersister.username));
                if (!cp.IsInRole(Roles))
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "denegado", action = "index" }));
            }
            }
        }
    
}