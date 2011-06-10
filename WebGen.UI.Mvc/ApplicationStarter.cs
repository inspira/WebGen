using System.Web.Mvc;
using WebGen.ApplicationServices.InversionOfControl;
using WebGen.Infrastructure.InversionOfControl;

namespace WebGen
{
    public static class ApplicationStarter
    {
        public static IDependencyResolver GetResolver(IInversionOfControlMapper mapper)
        {
            var abstractContainer = new StructureMapContainer();
			if (mapper != null) {
            	mapper.DefineMappings(abstractContainer);
			}
            return new SmDependencyResolver(abstractContainer);
        }
    }
}