using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Site.Model.Entities;

namespace Site.Model
{
    public class ConfigurationSettings : IConfigurationSettings
    {

        private IPersistenceConfigurer _persistence = null;

        public ConfigurationSettings(IPersistenceConfigurer persistence)
        {
            _persistence = persistence;
        }

        public static readonly AutoPersistenceModel Map = AutoMap.AssemblyOf<BlogEntry>().Where(t => t.Namespace.Contains("Entities"));

        private IPersistenceConfigurer _persistenceConfig;

        public IPersistenceConfigurer PersistenceConfig
        {
            get
            {
                return _persistence;
            }
        }

        public AutoPersistenceModel Mapping
        {
            get { return Map; }
        }

       
    }
}