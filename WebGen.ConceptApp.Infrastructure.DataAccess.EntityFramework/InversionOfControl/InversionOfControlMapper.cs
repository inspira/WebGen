using WebGen.ConceptApp.Domain.Repositories;
using WebGen.ConceptApp.Infrastructure.DataAccess.EntityFramework;
using WebGen.ApplicationServices.InversionOfControl;

namespace WebGen.ConceptApp.Infrastructure.InversionOfControl
{
    public class InversionOfControlMapper : IInversionOfControlMapper
    {
        public void DefineMappings(IInversionOfControlContainer container)
        {
            container.RegisterTypeHttpContextManaged<AppContext>();
            container.RegisterType<IRepositorioDeClientes, ClienteDao>();
        }
    }
}