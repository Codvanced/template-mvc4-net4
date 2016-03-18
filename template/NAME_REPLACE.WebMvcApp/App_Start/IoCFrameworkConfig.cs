using IOC.FW.Abstraction.Container.Binding;
using IOC.FW.ContainerManager.DryIoc;
using IOC.FW.Web.MVC.DIContainer.DryIoc;
using NAME_REPLACE.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NAME_REPLACE.WebMvcApp
{
    public static class IoCFrameworkConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var adapter = new DryIocAdapter();
            var ioc = new DryIocDependencyResolver(adapter._container);

            var binders = new IBinding[]{
                new BusinessBinder(),
                new DaoBinder(),
                new SharedBinder(),
                new IoCFrameworkBinder(),
            };

            foreach (var binder in binders)
                binder.SetBinding(adapter);

            System.Web.Mvc.DependencyResolver.SetResolver(ioc);
        }
    }
}