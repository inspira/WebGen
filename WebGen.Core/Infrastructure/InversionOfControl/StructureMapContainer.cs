using System;
using System.Linq;
using StructureMap;
using WebGen.ApplicationServices.InversionOfControl;

namespace WebGen.Infrastructure.InversionOfControl
{
    public class StructureMapContainer : IInversionOfControlContainer
    {
        global::StructureMap.Container container = new global::StructureMap.Container();
        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            container.Configure(x => x.For<TFrom>().Use<TTo>());
        }

        public void RegisterType(Type interfaceType, Type implementationType)
        {
            container.Configure(x =>
            {
                x.For(interfaceType).Use(implementationType);
            });
        }

        public void RegisterInstance<T>(T obj)
        {
            container.Configure(x =>
            {
                x.For<T>().Use(obj);
            });
        }

        public void RegisterDelayedInstance<T>(Func<T> delayedExpression)
        {
            container.Configure(x =>
            {
                x.For<T>().Use(delayedExpression);
            });
        }

        public T Resolve<T>()
        {
            return container.GetInstance<T>();
        }

        public void RegisterTypeHttpContextManaged<T>()
        {
            RegisterTypeHttpContextManaged<T, T>();
        }

        public void RegisterTypeHttpContextManaged<TFrom, TTo>() where TTo : TFrom
        {
            container.Configure(x =>
            {
                x.For<TFrom>().HybridHttpOrThreadLocalScoped().Use<TTo>();
            });
        }

        public object Resolve(Type t)
        {
            return container.GetInstance(t);
        }

        public System.Collections.Generic.IEnumerable<object> ResolveAll(Type t)
        {
            return container.GetAllInstances<object>().Where(s => s.GetType() == t);
        }

        public object TryResolve(Type t)
        {
            return container.TryGetInstance(t);
        }

        public void RegisterTypeHttpContextManaged<T>(Func<T> func)
        {
            container.Configure(x =>
            {
                x.For<T>().HybridHttpOrThreadLocalScoped().Use(func);
            });
        }

        public T TryResolve<T>()
        {
            return container.TryGetInstance<T>();
        }
    }
}
