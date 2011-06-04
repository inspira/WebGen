using System;
using System.Web.Mvc;
using WebGen.ConceptApp.Domain.Entities;
using WebGen.ConceptApp.Domain.Repositories;

namespace  WebGen.ConceptApp.UI.Mvc.Areas.Public.Controllers
{
    public class RepositoryTestsController : Controller
    {
        private readonly IRepositorioDeClientes repositorioDeClientes;
        public RepositoryTestsController(IRepositorioDeClientes repositorioDeClientes)
        {
            this.repositorioDeClientes = repositorioDeClientes;
        }

        public ActionResult GetAll()
        {
            var clientes = repositorioDeClientes.Listar();
            String resultado = "Clientes:\n";
            foreach (var cliente in clientes)
            {
                resultado += cliente.Nome;
            }
            return Content(resultado);
        }

        public ActionResult Insert()
        {
            var cliente = new Cliente
            {
                Nome = "Cliente salvo em : " + DateTime.Now
            };
            repositorioDeClientes.Salvar(cliente);
            return Content("Inserted: " + cliente.Nome);
        }
    }
}