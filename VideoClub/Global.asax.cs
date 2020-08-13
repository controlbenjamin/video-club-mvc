using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using VideoClub.App_Start;

namespace VideoClub
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            //agregar automapper
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());



            //agregar una Api al proyecto
            GlobalConfiguration.Configure(WebApiConfig.Register);



            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
