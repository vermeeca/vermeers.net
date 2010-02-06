using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using FluentNHibernate.Cfg.Db;
using Nerddinner.Controllers;
using NHibernate;
using Ninject.Modules;

namespace Site
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {

            //Configuration
            Bind<Site.Model.Configuration>().ToSelf().InRequestScope().OnActivation(c => c.Configure());

            var types = Assembly.GetExecutingAssembly().GetTypes();

            //default conventions (IMyService binds to MyService)
            var bindings = (from t1 in types
                            from t2 in types
                            where t1.IsImplementationOf(t2)
                            select new { Implementation = t1, Service = t2 })
                           .ToList();

            bindings.ForEach(b => Bind(b.Service).To(b.Implementation));

            //all repositories
            types.Where(t => t.Name.EndsWith("Repository")).ToList().ForEach(b => Bind(b).ToSelf());

            //ISession maps to the OpenSession() method on the configuration class
            Bind<ISession>().ToMethod(c => Global.CurrentSession);

            Bind<IFormsAuthentication>().To<FormsAuthenticationService>();
            Bind<IMembershipService>().To<AccountMembershipService>();
            Bind<MembershipProvider>().ToMethod(m => Membership.Provider);

            Bind<IPersistenceConfigurer>().ToMethod(p => SQLiteConfiguration.Standard.UsingFile(HttpContext.Current.Request.MapPath(@"~/App_Data/Site.db")));


        }
    }
}
