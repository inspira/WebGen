using System;
using System.Collections.Generic;

namespace WebGen.ApplicationServices.InversionOfControl
{
    public interface IInversionOfControlContainer
    {
        void RegisterType<TFrom, TTo>() where TTo : TFrom;
        void RegisterType(Type interfaceType, Type implementationType);
        void RegisterInstance<T>(T obj);
        void RegisterTypeHttpContextManaged<TFrom, TTo>() where TTo : TFrom;
        void RegisterTypeHttpContextManaged<T>();
        void RegisterTypeHttpContextManaged<T>(Func<T> func);

        /// <summary>
        /// Passes a parameter to the constructor in the moment the class is instantiated
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        void RegisterDelayedInstance<T>(Func<T> delayedExpression);
        T Resolve<T>();
        Object Resolve(Type t);
        IEnumerable<object> ResolveAll(Type serviceType);
        Object TryResolve(Type serviceType);
        T TryResolve<T>();
    }
}
