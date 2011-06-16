using System;
using System.Data.Entity;
using WebGen.ConceptApp.Domain.Entities;

namespace WebGen.ConceptApp.Infrastructure.DataAccess.EntityFramework
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base()
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
