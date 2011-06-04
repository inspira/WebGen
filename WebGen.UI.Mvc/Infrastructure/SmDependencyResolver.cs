using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebGen.ApplicationServices.InversionOfControl;

namespace WebGen.Infrastructure.InversionOfControl
{
    public class SmDependencyResolver : IDependencyResolver {
        private readonly IInversionOfControlContainer _container;

        public SmDependencyResolver(IInversionOfControlContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType) {
            if (serviceType == null) return null;
            return serviceType.IsAbstract || serviceType.IsInterface
                     ? _container.TryResolve(serviceType)
                     : _container.Resolve(serviceType);            
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return _container.ResolveAll(serviceType);
        }
    }
}