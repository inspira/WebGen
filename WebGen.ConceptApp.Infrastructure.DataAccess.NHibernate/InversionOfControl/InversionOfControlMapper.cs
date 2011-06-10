using WebGen.ConceptApp.Domain.Repositories;
using WebGen.ApplicationServices.InversionOfControl;
using NHibernate;
using WebGen.ConceptApp.Infrastructure.DataAccess.NHibernate;
using NHibernate.Cfg;
using WebGen.ConceptApp.Domain.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Automapping;
using System.Web;
using NHibernate.ByteCode.LinFu;
using FluentNHibernate.Cfg.Db;

namespace WebGen.ConceptApp.UI.Mvc.InversionOfControl
{
    public class InversionOfControlMapper : IInversionOfControlMapper
    {
        public void DefineMappings(IInversionOfControlContainer container)
        {
            container.RegisterTypeHttpContextManaged<ISession>(
                () => { return OpenSession(); }
            );
            container.RegisterType<IRepositorioDeClientes, ClienteDao>();
        }

        private ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var cfg = new Configuration();
            cfg.Configure();
            return Fluently.Configure(cfg)
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Cliente>())

                ).ProxyFactoryFactory(typeof(ProxyFactoryFactory).AssemblyQualifiedName)
                .BuildSessionFactory();
            //            .ExposeConfiguration(Cfg => _cfg = Cfg)            .BuildSessionFactory();

        }

        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = CreateSessionFactory();
                } return _sessionFactory;
            }
        }
    }
}