using ExplosiveRouting.Discovery;
using ExplosiveRouting.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Execution_OverloadedExecuteThrow()
        {
            Assert.Throws<Exception>(() => _router.RouteAsync(new object(), "echo 1", throwOnAmbiguous: true).Wait());
        }

        [Test]
        public void Execution_OverloadedExecute()
        {
            Assert.DoesNotThrow(() => _router.RouteAsync(new object(), "echo 1 2 3 4 5").Wait());
            Assert.AreEqual(15, TestModule.LastInt);
        }
    }

    public class TestModule : RouteController<object>
    {
        public static int LastInt { get; set; }

        [Route("echo")]
        public Task TestAsync(int test)
        {
            LastInt = test;
            return Task.CompletedTask;
        }

        [Route("echo")]
        public Task TestAsync(params int[] test)
        {
            LastInt = test.Sum();
            return Task.CompletedTask;
        }
    }
}
