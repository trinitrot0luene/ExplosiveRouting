using ExplosiveRouting.Discovery;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace ExplosiveRouting.Tests.Core
{
    [TestFixture]
    public class RouteMapperTests
    {
        private readonly IServiceCollection _services = new ServiceCollection();

        [Test]
        public void RouteMapper_Create()
        {
            var mapper = new RouteMapper<object>();
            Assert.IsInstanceOf<IRouteMapper<object>>(mapper);
        }

        [Test]
        public void RouteMapper_AddType()
        {
            IRouteMapper<object> mapper = new RouteMapper<object>();

            mapper.AddRoute(typeof(MockRoute), _services);
        }

        [Test]
        public void RouteMapper_AddInvalid()
        {
            IRouteMapper<object> mapper = new RouteMapper<object>();

            Assert.Throws<ArgumentException>(() => mapper.AddRoute(typeof(object), _services));
        }

        [Test]
        public void RouteMapper_AddAndSearch()
        {
            IRouteMapper<object> mapper = new RouteMapper<object>();

            mapper.AddRoute(typeof(MockRoute), _services);
            mapper.AddRoute(typeof(MockRoute2), _services);

            Assert.True(mapper.TryGetRoute(new[] { "test" }, out var route));
            Assert.NotNull(route.Item1);

            Assert.True(mapper.TryGetRoute(new[] { "test2" }, out var nestedRoute));
            Assert.NotNull(nestedRoute.Item1);

            Assert.True(mapper.TryGetRoute(new[] { "test3", "test4" }, out var nestedRoute2));
            Assert.NotNull(nestedRoute2.Item1);

            Assert.True(mapper.TryGetRoute(new[] { "test5", "test6" }, out var route2));
            Assert.NotNull(route2.Item1);
        }

        [Test]
        public void RouteMapper_WrongReturnType()
        {
            IRouteMapper<object> mapper = new RouteMapper<object>();

            Assert.Throws<ArgumentException>(() => mapper.AddRoute(typeof(MockRoute3), _services));
        }
    }

    public class MockRoute : RouteController<object>
    {
        [Route("test")]
        public Task TestAsync()
        {
            return Task.CompletedTask;
        }

        public class NestedMockRoute : RouteController<object>
        {
            [Route("test2")]
            public Task TestAsync2()
            {
                return Task.CompletedTask;
            }
        }

        [Route("test3")]
        public class SecondNestedMockRoute : RouteController<object>
        {
            [Route("test4")]
            public Task TestAsync4(int a)
            {
                return Task.CompletedTask;
            }
        }
    }

    [Route("test5")]
    public class MockRoute2 : RouteController<object>
    {
        [Route("test6")]
        public Task TestRoute6Async()
        {
            return Task.CompletedTask;
        }
    }

    public class MockRoute3
    {
        [Route("broken")]
        public int BrokenRoute()
        {
            return -1;
        }
    }
}
