using ExplosiveRouting.Core.Middleware;
using ExplosiveRouting.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Tests.Middleware
{
    public sealed class DemoInjectedMiddleware : IMiddleware
    {
        private Random Random { get; set; }

        public DemoInjectedMiddleware(Random random)
        {
            Random = random;
        }

        public IResult Run(IContext context)
        {
            if (Random != null)
                return new OkResult();
            else
                return new ErrorResult();
        }
    }
}
