using ExplosiveRouting.Discovery;
using ExplosiveRouting.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExplosiveRouting.Tests.Core
{
    [TestFixture]
    public class RouterExecutionTests
    {
        private Router<object> _router;

        [SetUp]
        public void ConfigureRouter()
        {
            _router = new RouterBuilder<object>()
                .UseDefaultParser()
                .UseDefaultTypeMapping()
                .UseDefaultRouteMapping()
                .Build();
        }

        [Test]
        public async Task Execution_Execute()
        {
            await _router.RouteAsync(new object(), "echo 1");
        }
    }

    public class TestModule : RouteController<object>
    {
        [Route("echo")]
        public Task TestAsync(int test)
        {
            return Task.CompletedTask;
        }
    }
}
