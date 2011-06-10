using System.Collections.Generic;
using System.Linq;
using WebGen.ConceptApp.Domain.Entities;
using WebGen.ConceptApp.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace WebGen.ConceptApp.Infrastructure.DataAccess.NHibernate
{
    public class ClienteDao : IRepositorioDeClientes
    {
        private readonly ISession session;
        private readonly IQueryable<Cliente> clientes;
        public ClienteDao(ISession session)
        {
            this.session = session;
            this.clientes = session.Query<Cliente>();
        }

        public IEnumerable<Cliente> Listar()
        {
            return clientes.ToList();
        }

        public void Salvar(Cliente cliente)
        {
            session.SaveOrUpdate(cliente);
        }
    }
}
