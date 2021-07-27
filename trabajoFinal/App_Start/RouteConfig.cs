using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace trabajoFinal {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{usuario}/{clave}",
            //    defaults: new { controller = "Home", action = "Index", usuario = UrlParameter.Optional, clave = UrlParameter.Optional }
            //);
            routes.MapRoute(
               name: "Persona",
               url: "{controller}/{action}/{rut}/{confirmacion}",
               defaults: new { controller = "Persona", action = "Login", rut = UrlParameter.Optional, confirmacion = UrlParameter.Optional}             
           );
        }
    }
}
