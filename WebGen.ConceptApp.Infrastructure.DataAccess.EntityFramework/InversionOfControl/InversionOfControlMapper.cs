using WebGen.ConceptApp.Domain.Repositories;
using WebGen.ConceptApp.Infrastructure.DataAccess.EntityFramework;
using WebGen.ApplicationServices.InversionOfControl;
using WebGen.Infrastructure.DataAccess;
using System.Data.Entity;

namespace WebGen.ConceptApp.Infrastructure.InversionOfControl
{
    public class InversionOfControlMapper : IInversionOfControlMapper
    {
        public void DefineMappings(IInversionOfControlContainer container)
        {
            container.RegisterDelayedInstance<AppContext>(
                    () =>
                    {
                        if (!System.Web.HttpContext.Current.Items.Contains("DbContext"))
                        {
                            System.Web.HttpContext.Current.Items["DbContext"] = new AppContext();
                        }
                        return (AppContext)System.Web.HttpContext.Current.Items["DbContext"];
                    }
                );
            container.RegisterType<IRepositorioDeClientes, ClienteDao>();
            container.RegisterType<IOrmPersister, EntityFrameworkPersister>();
        }
    }
}