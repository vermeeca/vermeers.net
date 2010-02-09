using System;
using System.Web.Security;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Site.Model
{
    /// <summary>
    /// Holds configuration values for the application
    /// </summary>
    public interface IConfigurationSettings
    {
        /// <summary>
        /// The Fluent NHibernate persistence configuration
        /// </summary>
        IPersistenceConfigurer PersistenceConfig { get; }
        /// <summary>
        /// The Fluent NHibernate Mapping
        /// </summary>
        AutoPersistenceModel Mapping { get; }
        /// <summary>
        /// The ASP.Net Membership provider
        /// </summary>
        MembershipProvider Membership { get; }

        /// <summary>
        /// Retrieves the current session
        /// </summary>
        ISession GetCurrentSession();

    }
}