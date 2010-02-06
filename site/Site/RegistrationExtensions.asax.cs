using System;
using System.Linq;

namespace Site
{
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