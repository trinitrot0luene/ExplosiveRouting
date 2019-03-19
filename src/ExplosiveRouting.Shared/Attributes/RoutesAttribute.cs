using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class RoutesAttribute : Attribute
    {
        public string[] Routes { get; }

        public RoutesAttribute(params string[] routes)
        {
            Routes = routes;
        }
    }
}
