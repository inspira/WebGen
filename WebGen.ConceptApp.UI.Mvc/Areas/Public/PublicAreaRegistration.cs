using System.Web.Mvc;

namespace WebGen.ConceptApp.UI.Mvc.Areas.Public
{
    public class PublicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Public";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Public_default",
                "{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional },
                new [] { this.GetType().Namespace + ".Controllers" }
            );
        }
    }
}
