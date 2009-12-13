using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace Site.Model
{
    /// <summary>
    /// Describes the Fluent Nhibernate Config that the repositories should use
    /// </summary>
    public interface IMappingConfig
    {
        IPersistenceConfigurer PersistenceConfig { get; }
        AutoPersistenceModel Mapping { get; }

        FluentConfiguration GetConfiguration();
    }
}