using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebGen.ConceptApp.Domain.Entities;
using WebGen.ConceptApp.Domain.Repositories;

namespace WebGen.ConceptApp.Infrastructure.DataAccess.EntityFramework
{
    public class ClienteDao : IRepositorioDeClientes
    {
        private readonly AppContext context;
        private readonly DbSet<Cliente> clientes;
        public ClienteDao(AppContext context)
        {
            this.context = context;
            this.clientes = context.Clientes;
        }

        public IEnumerable<Cliente> Listar()
        {
            return clientes.ToList();
        }

        public void Salvar(Cliente cliente)
        {
            clientes.Add(cliente);
        }
    }
}
