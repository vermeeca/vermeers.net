using System;
using System.Diagnostics;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Site.Model
{
    public class Configuration
    {
        private IConfigurationSettings _settings;
        private ISessionFactory _sessionFactory;

        public FluentConfiguration FluentConfiguration { get; set; }

        public Configuration(IConfigurationSettings settings)
        {
            _settings = settings;
        }

        public Configuration Configure()
        {

            FluentConfiguration = Fluently.Configure()
                .Database(_settings.PersistenceConfig)
                .Mappings(m => m.AutoMappings.Add(_settings.Mapping));

            
            _sessionFactory = FluentConfiguration.BuildSessionFactory();
            

            return this;
        
        }

        public void EnsureDatabaseCreated()
        {
            using(var session = OpenSession())
            {
                new SchemaExport(FluentConfiguration.BuildConfiguration()).Execute(true, true, false, session.Connection, Console.Out);
            }
        }

        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}