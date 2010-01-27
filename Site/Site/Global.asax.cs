using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using NHibernate;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Site.Model;

namespace Site
{
    public class Global : NinjectHttpApplication
    {
        static readonly Application _application = new Application();

        public Global()
        {
            this.BeginRequest += (o, e) => CurrentSession = Kernel.Get<Site.Model.Configuration>().OpenSession();
            this.EndRequest += (o, e) =>
            {
                if (CurrentSession != null)
                {
                    CurrentSession.Flush();
                    CurrentSession.Dispose();
                }
            };            
        }

        public static ISession CurrentSession
        {
            get { return (ISession)HttpContext.Current.Items["current.session"]; }
            set { HttpContext.Current.Items["current.session"] = value; }
        }

        protected override void OnApplicationStarted()
        {
            _application.RegisterViewEngines(ViewEngines.Engines);
            _application.RegisterRoutes(RouteTable.Routes);
            RegisterAllControllersIn(Assembly.GetExecutingAssembly());

            
        }


        protected override Ninject.IKernel CreateKernel()
        {
            return new StandardKernel(new ServiceModule());
        }
      

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // this ensures Default.aspx will be processed
            var context = ((HttpApplication)sender).Context;
            var relativeFilePath = context.Request.AppRelativeCurrentExecutionFilePath;
            if (relativeFilePath == "~/" ||
                string.Equals(relativeFilePath, "~/default.aspx", StringComparison.InvariantCultureIgnoreCase))
            {
                context.RewritePath("~/Home");
            }
        }

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
                               select new {Implementation = t1, Service = t2})
                               .ToList();

                bindings.ForEach(b => Bind(b.Service).To(b.Implementation));

                //all repositories
                types.Where(t => t.Name.EndsWith("Repository")).ToList().ForEach(b => Bind(b).ToSelf());

                //ISession maps to the OpenSession() method on the configuration class
                Bind<ISession>().ToMethod(c => Global.CurrentSession);              

            }
        }

        
        

        
    }

    internal static class RegistrationExtensions
    {
        public static bool IsImplementationOf(this Type implementation, Type service)
        {
            return 
                string.Format("I{0}", implementation.Name).Equals(service.Name)
                && implementation.GetInterfaces().Contains(service);
        }       
    }
}