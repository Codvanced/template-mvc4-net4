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
using IOC.FW.Core.Abstraction.Container.Binding;
using IOC.FW.ContainerManager.DryIoc;

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

            var adapter = new DryIocAdapter();
            var ioc = new DryIocDependencyResolver(adapter._container);

            var binders = new IBinding[]{
                new BusinessBinder(),
                new DaoBinder(),
                new SharedBinder(),
                new FrameworkBinder(),
            };

            foreach (var binder in binders)
                binder.SetBinding(adapter);

            ControllerBuilder.Current.SetControllerFactory(ioc); 
        }
    }

    class DryIocDependencyResolver : System.Web.Mvc.DefaultControllerFactory
    {
        private readonly IContainer _container;

        public DryIocDependencyResolver(DryIoc.Container container)
        {
            _container = container;
            RegisterTheIocs();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            System.Web.Mvc.IController ic = controllerType == null
                ? null
                : (System.Web.Mvc.IController)_container.Resolve(controllerType);

            return ic;
        }

        void RegisterTheIocs()
        {

            var allControllers = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(
                    type => type.IsSubclassOf(
                        typeof(Controller)
                    )
                ).ToList();

            foreach (var controller in allControllers)
            {
                _container.Register(controller, DryIoc.Reuse.InResolutionScope);
            }
        }
    }
}