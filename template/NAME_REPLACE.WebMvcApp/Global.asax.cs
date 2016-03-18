using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using DryIoc;
using System.Reflection;
using NAME_REPLACE.Binding;
using IOC.FW.ContainerManager.DryIoc;
using IOC.FW.Abstraction.Container.Binding;

namespace NAME_REPLACE.WebMvcApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IoCFrameworkConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}