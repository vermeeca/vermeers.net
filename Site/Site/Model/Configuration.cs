using System;
using System.Diagnostics;
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

            try
            {
                _sessionFactory = FluentConfiguration.BuildSessionFactory();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return this;
        
        }

        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}