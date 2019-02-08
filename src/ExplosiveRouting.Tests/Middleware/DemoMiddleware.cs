using ExplosiveRouting.Middleware;
using ExplosiveRouting.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Tests.Middleware
{
    public sealed class DemoMiddleware : IMiddleware
    {
        public IResult Run(IContext context)
        {
            return new OkResult();
        }
    }
}
