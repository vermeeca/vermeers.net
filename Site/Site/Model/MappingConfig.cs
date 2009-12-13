using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Site.Model.Entities;

namespace Site.Model
{
    public class MappingConfig : IMappingConfig
    {


        public static readonly AutoPersistenceModel Map = AutoMap.AssemblyOf<BlogEntry>().Where(t => t.Namespace.Contains("Entities"));

        private IPersistenceConfigurer _persistenceConfig;

        public IPersistenceConfigurer PersistenceConfig
        {
            get
            {
                if(_persistenceConfig == null)
                {
                    _persistenceConfig = SQLiteConfiguration.Standard.UsingFile("site.db");
                }

                return _persistenceConfig;
            }
            set
            {
                _persistenceConfig = value;
            }
        }

        public AutoPersistenceModel Mapping
        {
            get { return Map; }
        }

        public FluentConfiguration GetConfiguration()
        {
            return Fluently.Configure()
                .Database(PersistenceConfig)
                .Mappings(m => m.AutoMappings.Add(Mapping));
        }
    }
}