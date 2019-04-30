using ExplosiveRouting.Discovery;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting
{
    public class RouterBuilder<TContext>
    {
        public IServiceCollection Services { get; } = new ServiceCollection();

        public Router<TContext> Build()
        {
            var provider = Services.BuildServiceProvider();

            provider.GetRequiredService<IParser>();
            provider.GetRequiredService<ITypeMapper>();
            provider.GetRequiredService<IRouteMapper<TContext>>();

            return new Router<TContext>(this.Services, provider);
        }
    }
}
