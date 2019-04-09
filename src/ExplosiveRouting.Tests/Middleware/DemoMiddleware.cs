using ExplosiveRouting.Core.Middleware;
using ExplosiveRouting.Core;
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
