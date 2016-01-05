using IOC.FW.Core.Abstraction.Business;
using IOC.FW.Core.Abstraction.Container;
using IOC.FW.Core.Abstraction.Container.Binding;
using IOC.FW.Core.Abstraction.Logging;
using IOC.FW.Core.Abstraction.Repository;
using IOC.FW.Core.Implementation.Base;
using IOC.FW.Logging.Log4net;
using IOC.FW.Repository;
using IOC.FW.Repository.ADO;
using IOC.FW.Repository.EntityFramework;
using IOC.FW.Shared.Enumerators;

using System;
using System.Collections.Generic;

namespace NAME_REPLACE.Binding
{
    public class FrameworkBinder : IBinding
    {
        public void SetBinding(IAdapter adapter)
        {
            adapter.Register(
                typeof(IBaseBusiness<>),
                typeof(BaseBusiness<>),
                ContainerEnumerator.LifeCycle.Transient
            );

            adapter.Register(
                typeof(IContextFactory<>),
                typeof(ContextFactory<>),
                ContainerEnumerator.LifeCycle.Singleton
            );

            adapter.Register(
                typeof(IRepositoryFactory<>),
                typeof(RepositoryFactory<>),
                ContainerEnumerator.LifeCycle.Singleton
            );

            adapter.Register(
                typeof(IRepository<>),
                typeof(EntityFrameworkRepository<>),
                ContainerEnumerator.LifeCycle.Transient
            );

            adapter.RegisterMany(
                typeof(IRepository<>),
                new Dictionary<object, Type>
                {
                    {
                        RepositoryEnumerator.RepositoryType.EntityFramework,
                        typeof(EntityFrameworkRepository<>)
                    },
                    {
                        RepositoryEnumerator.RepositoryType.ADO,
                        typeof(ADORepository<>)
                    }
                },
                ContainerEnumerator.LifeCycle.Transient
            );

            adapter.Register(
                typeof(ILogger), 
                typeof(Log4NetAdapter), 
                ContainerEnumerator.LifeCycle.Singleton
            );
        }
    }
}
