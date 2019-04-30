using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Discovery
{
    public interface IRouteMapper<TContext>
    {
        bool TryGetRoute(string[] path, out Route value, bool throwOnAmbigious = false, StringComparison comparisonStrategy = StringComparison.Ordinal);

        void AddRoute(Type containingType);
    }
}
