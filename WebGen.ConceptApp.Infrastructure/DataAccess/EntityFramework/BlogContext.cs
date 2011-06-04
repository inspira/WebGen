using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using WebGen.ConceptApp.Domain.Entities;
using WebGen.ConceptApp.Infrastructure.DataAccess;

namespace WebGen.ConceptApp.Infrastructure.DataAccess.EntityFramework
{
    public class AppContext : DbContext
    {
        public AppContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppContext>());
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
