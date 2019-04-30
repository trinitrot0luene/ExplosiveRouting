using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Discovery
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class RouteAttribute : Attribute
    {
        public string[] Routes { get; }

        public RouteAttribute(params string[] routes)
        {
            Routes = routes;
        }
    }
}
