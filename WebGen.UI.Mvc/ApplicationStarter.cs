using System;
using System.Web.Mvc;
using WebGen.ApplicationServices.InversionOfControl;
using WebGen.Infrastructure.InversionOfControl;

namespace WebGen
{
    public static class ApplicationStarter
    {
        public static IInversionOfControlContainer container;
        public static IInversionOfControlContainer Container
        {
            get
            {
                return container;
            }
        }

        public static IDependencyResolver GetResolver(IInversionOfControlMapper mapper)
        {
            container = new StructureMapContainer();
			if (mapper != null) {
            	mapper.DefineMappings(container);
			}
            return new SmDependencyResolver(container);
        }
    }
}