using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebGen.ApplicationServices.InversionOfControl;
using System.Data.Entity;

namespace WebGen.Infrastructure.DataAccess
{
    public class EntityFrameworkPersister : IOrmPersister
    {
        public void SaveChanges(IInversionOfControlContainer container)
        {
            if (System.Web.HttpContext.Current.Items.Contains("DbContext"))
            {
                var context = (DbContext)System.Web.HttpContext.Current.Items["DbContext"];
                if (context != null)
                {
                    context.SaveChanges();
                }
            }
        }
    }
}
