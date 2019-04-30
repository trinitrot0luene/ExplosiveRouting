using System;
using System.Linq;
using System.Reflection;

namespace ExplosiveRouting.Discovery
{
    public class Route : RouteNode
    {
        private ParameterInfo[] _parameters;

        internal int RequiredParamCount { get; private set; }

        public ParameterInfo[] Parameters
        {
            get => _parameters;
            internal set
            {
                _parameters = value;
                RequiredParamCount = _parameters
                    .Where(p => !p.IsOptional)
                    .Count();
            }
        }

        public Attribute[] Attributes { get; internal set; }

        public MethodInfo MethodInfo { get; internal set; }

        internal Func<object, object[], object> Callback { get; set; }
    }
}
