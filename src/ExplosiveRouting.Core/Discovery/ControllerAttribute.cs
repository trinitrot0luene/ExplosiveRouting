using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Discovery
{
    public sealed class ControllerAttribute : Attribute
    {
        public ServiceLifetime ServiceLifetime { get; }

        public ControllerAttribute(ServiceLifetime ServiceLifetime = ServiceLifetime.Transient)
        {
            this.ServiceLifetime = ServiceLifetime;
        }
    }
}
