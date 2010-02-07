using System;
using System.Web.Security;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Site.Model
{
    /// <summary>
    /// Describes the Fluent Nhibernate Config that the repositories should use
    /// </summary>
    public interface IConfigurationSettings
    {
        IPersistenceConfigurer PersistenceConfig { get; }
        AutoPersistenceModel Mapping { get; }
        MembershipProvider Membership { get; }
        ISession CurrentSession { get; }

    }
}