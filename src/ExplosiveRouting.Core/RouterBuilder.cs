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

            // Validate that the minimum required services are present.
            try
            {
                provider.GetRequiredService<IParser>();
                provider.GetRequiredService<ITypeMapper>();
                provider.GetRequiredService<IRouteMapper<TContext>>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An exception was thrown while attempting to get a required router service. Check the inner exception for more details.", ex);
            }

            return new Router<TContext>(this.Services, provider);
        }
    }
}
