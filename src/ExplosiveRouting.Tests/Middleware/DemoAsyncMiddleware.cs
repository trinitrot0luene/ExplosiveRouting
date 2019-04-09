using ExplosiveRouting.Core.Middleware;
using ExplosiveRouting.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExplosiveRouting.Tests.Middleware
{
    public sealed class DemoAsyncMiddleware : IAsyncMiddleware
    {
        public Task<IResult> RunAsync(IContext context)
        {
            return Task.FromResult(new OkResult() as IResult);
        }
    }
}
