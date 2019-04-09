using ExplosiveRouting.Core.Middleware;
using ExplosiveRouting.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Tests.Middleware
{
    public sealed class DemoMiddleware<TContext> : IMiddleware<TContext>
    {
        public IResult Run(TContext context)
        {
            return new OkResult();
        }
    }
}
