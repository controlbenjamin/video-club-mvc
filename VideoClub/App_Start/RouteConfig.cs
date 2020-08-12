using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VideoClub
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //habilitar las rutas en cada action
            routes.MapMvcAttributeRoutes();



            /*
             * FORMA VIEJA DE HACERLO
             * 
            routes.MapRoute(
                "PeliculasPorFechaLanzamiento",
                "peliculas/lanzamiento/{ano}/{mes}",
                new { controller = "Peliculas", action = "PorFechaDeLanzamiento" },
                new { ano = @"2015|2016", mes = @"\d{2}" });

            */


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
