using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using WebGen.ApplicationServices.InversionOfControl;
using WebGen.ConceptApp.Domain.Entities;
using WebGen.ConceptApp.Domain.Repositories;
using WebGen.ConceptApp.Infrastructure.DataAccess.NHibernate;
using NHibernate.ByteCode.LinFu;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace WebGen.ConceptApp.Infrastructure.InversionOfControl
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
        {/*
            Configuration _cfg  = null;

			 var factory = Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard.InMemory()
                    // .UsingFile(@"C:\Users\thiago.alves\Desktop\firstProject.db")
                )
                .ProxyFactoryFactory(typeof(ProxyFactoryFactory))            
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Cliente>()))
                .ExposeConfiguration(Cfg => _cfg = Cfg)
                .BuildSessionFactory();*/
            			var cfg = new global::NHibernate.Cfg.Configuration();
            cfg.Configure();
		
            return Fluently.Configure(cfg)
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Cliente>())

                )
                .ProxyFactoryFactory(typeof(ProxyFactoryFactory).AssemblyQualifiedName)
                .BuildSessionFactory();
            
            //return cfg.BuildSessionFactory();

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