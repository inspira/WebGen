using System.Collections.Generic;
using WebGen.ConceptApp.Domain.Entities;

namespace WebGen.ConceptApp.Domain.Repositories
{
    public interface IRepositorioDeClientes
    {
        IEnumerable<Cliente> Listar();
        void Salvar(Cliente cliente);
    }
}
