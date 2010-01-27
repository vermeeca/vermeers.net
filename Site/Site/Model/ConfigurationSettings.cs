using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Site.Model.Entities;

namespace Site.Model
{
    public class ConfigurationSettings : IConfigurationSettings
    {


        public static readonly AutoPersistenceModel Map = AutoMap.AssemblyOf<BlogEntry>().Where(t => t.Namespace.Contains("Entities"));

        private IPersistenceConfigurer _persistenceConfig;

        public IPersistenceConfigurer PersistenceConfig
        {
            get
            {
                return SQLiteConfiguration.Standard.UsingFile("site.db").ShowSql();
            }
        }

        public AutoPersistenceModel Mapping
        {
            get { return Map; }
        }

       
    }
}