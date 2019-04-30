using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting
{
    public sealed class Router<TContext>
    {
        private IServiceCollection _serviceSource;

        private IServiceProvider _services;

        public Router(IServiceCollection serviceSource, IServiceProvider services)
        {
            this._serviceSource = serviceSource;
            this._services = services;
        }
    }
}
