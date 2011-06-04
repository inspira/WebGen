using System.Web.Mvc;
using System.Web.Routing;
using WebGen.ConceptApp.UI.Mvc.InversionOfControl;
using WebGen.Infrastructure.InversionOfControl;
using WebGen.ConceptApp.Infrastructure.DataAccess.EntityFramework;

namespace WebGen.ConceptApp.UI.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            DependencyResolver.SetResolver(ApplicationStarter.GetResolver(new InversionOfControlMapper()));
        }

        protected void Application_EndRequest()
        {
            var context = DependencyResolver.Current.GetService<AppContext>();
            if (context != null)
            {
                context.SaveChanges();
            }
        }
    }
}