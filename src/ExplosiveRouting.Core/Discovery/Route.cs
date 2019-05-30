using System;
using System.Linq;
using System.Reflection;

namespace ExplosiveRouting.Discovery
{
    public class Route : RouteNode
    {
        public ParameterInfo[] Parameters { get; set; }

        public Attribute[] Attributes { get; internal set; }

        public MethodInfo MethodInfo { get; internal set; }

        public RunMode RunMode { get; internal set; }

        internal Func<object, object[], object> Callback { get; set; }
    }
}
