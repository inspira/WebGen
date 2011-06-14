using System.Web.Mvc;
using System.Web.Routing;
using WebGen.Infrastructure.InversionOfControl;
using WebGen.ConceptApp.Infrastructure.InversionOfControl;
using WebGen.ConceptApp.Infrastructure.DataAccess.NHibernate;
using NHibernate;
//using WebGen.ConceptApp.Infrastructure.DataAccess.EntityFramework;

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
				));
        }

        protected void Application_EndRequest()
        {/*
             var context = DependencyResolver.Current.GetService<AppContext>();
            if (context != null)
            {
                context.SaveChanges();
            }
            */
            var session = DependencyResolver.Current.GetService<ISession>();
            if (session != null)
            {
                if (session.Transaction.IsActive)
                {
                    session.Transaction.Commit();
                };
                session.Flush();
                session.Close();
                session.Dispose();
            }
             
        }
    }
}