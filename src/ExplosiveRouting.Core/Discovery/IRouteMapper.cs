using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ExplosiveRouting.Discovery
{
    public interface IRouteMapper<TContext>
    {
        bool TryGetRoute(string[] path, out (Route, int) value, bool throwOnAmbigious = false, StringComparison comparisonStrategy = StringComparison.Ordinal);

        void AddRoute(Type containingType, IServiceCollection services);

        void AddRoute(Assembly assembly, IServiceCollection services);
    }
}
