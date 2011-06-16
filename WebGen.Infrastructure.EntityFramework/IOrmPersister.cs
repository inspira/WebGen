using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebGen.ApplicationServices.InversionOfControl;

namespace WebGen.Infrastructure.DataAccess
{
    public interface IOrmPersister
    {
        void SaveChanges(IInversionOfControlContainer container);
    }
}
