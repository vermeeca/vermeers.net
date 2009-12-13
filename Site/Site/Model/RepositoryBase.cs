using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Site.Model
{
    public abstract class RepositoryBase
    {

        protected ISession Session { get; set; }

        protected RepositoryBase(ISession session)
        {
            Session = session;
        }




    }
}