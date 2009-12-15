using System;
using FluentNHibernate.Cfg;
using NHibernate;

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

        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}