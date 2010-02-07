using System;
using System.Web;
using System.Web.Security;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Site.Model.Entities;

namespace Site.Model
{
    public class ConfigurationSettings : IConfigurationSettings
    {


        public ConfigurationSettings()
        {

        }

        public static readonly AutoPersistenceModel Map = AutoMap.AssemblyOf<BlogEntry>().Where(t => t.Namespace.Contains("Entities"));

        private IPersistenceConfigurer _persistenceConfig;

        public IPersistenceConfigurer PersistenceConfig
        {
            get
            {
                return SQLiteConfiguration.Standard.UsingFile(HttpContext.Current.Request.MapPath(@"~/App_Data/Site.db"));
            }
        }

        public AutoPersistenceModel Mapping
        {
            get { return Map; }
        }

        public MembershipProvider Membership
        {
            get { return System.Web.Security.Membership.Provider; }
        }

        public ISession CurrentSession
        {
            get { return Global.CurrentSession; }
        }
    }
       
}