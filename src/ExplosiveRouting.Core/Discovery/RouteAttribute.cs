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

        public RunMode RunMode { get; }

        public RouteAttribute(params string[] routes)
        {
            Routes = routes.Length == 0 ? new[] { "" } : routes;
            RunMode = RunMode.Sequential;
        }

        public RouteAttribute(RunMode runMode, params string[] routes)
        {
            Routes = routes.Length == 0 ? new[] { "" } : routes;
            RunMode = runMode;
        }
    }
}
