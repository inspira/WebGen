using System;
using WebGen.ConceptApp.Domain.Repositories;
using WebGen.ConceptApp.Infrastructure.DataAccess;
using WebGen.Core.Infrastructure;

namespace WebGen.ConceptApp.Infrastructure
{
    public static class IoC
    {
        public static void GetMappings(AbstractResolver container)
        {
            container.For<IRepositorioDeClientes>().Use<ClienteDao>();
        }

        public static object GetResolver()
        {
            //new StructureMapDependencyResolver(container);
            return null;
        }
    }
}