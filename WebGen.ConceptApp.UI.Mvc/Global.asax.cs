using System;
using System.Web.Mvc;
using System.Web.Routing;
using WebGen.ConceptApp.Infrastructure.InversionOfControl;
using WebGen.Infrastructure.DataAccess;
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

            DependencyResolver.SetResolver(
                ApplicationStarter.GetResolver(
                    new InversionOfControlMapper()
                )
            );
        }

        protected void Application_BeginRequest()
        {
            var x = 1;
        }

        protected void Application_EndRequest()
        {
            ApplicationStarter.Container.Resolve<IOrmPersister>().SaveChanges(ApplicationStarter.Container);
        }
    }
}