using ExplosiveRouting.Core.Middleware;
using ExplosiveRouting.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExplosiveRouting.Tests.Middleware
{
    public sealed class DemoAsyncMiddleware<TContext> : IAsyncMiddleware<TContext>
    {
        public Task<IResult> RunAsync(TContext context)
        {
            return Task.FromResult(new OkResult() as IResult);
        }
    }
}
