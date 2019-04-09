using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class RouteAttribute : Attribute
    {
        public string[] Routes { get; }

        public RouteAttribute(params string[] routes)
        {
            Routes = routes;
        }
    }
}
