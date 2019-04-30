using ExplosiveRouting.Discovery;
using ExplosiveRouting.Extensions;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ExplosiveRouting.Tests.Core
{
    [TestFixture]
    public class RouterTests
    {
        [Test]
        public void Router_Build()
        {
            var builder = new RouterBuilder<object>();
            Assert.IsInstanceOf<RouterBuilder<object>>(builder);

            Assert.Throws<InvalidOperationException>(() => builder.Build());
        }

        [Test]
        public void Router_BuildWithParser()
        {
            var builder = new RouterBuilder<object>();

            builder.UseDefaultParser();

            Assert.Throws<InvalidOperationException>(() => builder.Build());
        }

        [Test]
        public void Router_BuildWithConfiguredParser()
        {
            var builder = new RouterBuilder<object>();

            builder.UseDefaultParser(options =>
            {
                options.EscapeChars = new[] { '\\' };
            });

            Assert.Throws<InvalidOperationException>(() => builder.Build());
        }

        [Test]
        public void Router_BuildWithTypeMapper()
        {
            var builder = new RouterBuilder<object>();

            builder.UseDefaultTypeMapping();

            Assert.Throws<InvalidOperationException>(() => builder.Build());
        }

        [Test]
        public void Router_BuildWithRouteMapper()
        {
            var builder = new RouterBuilder<object>();

            builder.UseDefaultRouteMapping();

            Assert.Throws<InvalidOperationException>(() => builder.Build());
        }

        [Test]
        public void Router_BuildDefault()
        {
            var builder = new RouterBuilder<object>();

            builder.UseDefault();

            Assert.IsInstanceOf<Router<object>>(builder.Build());
        }

        [Test]
        public void TypeMapper_Create()
        {
            var discoverer = new TypeMapper();

            Assert.IsInstanceOf<ITypeMapper>(discoverer);
        }

        [Test]
        public async Task TypeMapper_AddAndUseMappingFromType()
        {
            var mapper = new TypeMapper();

            mapper.AddMapping(typeof(MockConverter));

            Assert.True(mapper.TryGetMapping(typeof(int), out var mapping));
            Assert.NotNull(mapping);

            var valTask = (Task)mapping(new MockConverter(), new object[] { new object(), "10" });

            var result = await valTask.ConvertAsync();

            Assert.AreEqual(10, (int)result);
        }

        [Test]
        public async Task TypeMapper_AddAndUseMappingFromAssembly()
        {
            var mapper = new TypeMapper();

            mapper.AddMapping(Assembly.GetAssembly(typeof(MockConverter)));

            Assert.True(mapper.TryGetMapping(typeof(int), out var mapping));
            Assert.NotNull(mapping);

            var valTask = (Task)mapping(new MockConverter(), new object[] { new object(), "10" });

            var result = await valTask.ConvertAsync();

            Assert.AreEqual(10, (int)result);
        }

        [Test]
        public void TypeMapper_RegisterInvalid()
        {
            var mapper = new TypeMapper();

            Assert.Throws<ArgumentException>(() => mapper.AddMapping(typeof(object)));
        }

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

            mapper.AddRoute(typeof(MockRoute));
        }

        [Test]
        public void RouteMapper_AddInvalid()
        {
            IRouteMapper<object> mapper = new RouteMapper<object>();

            Assert.Throws<ArgumentException>(() => mapper.AddRoute(typeof(object)));
        }

        [Test]
        public void RouteMapper_AddAndSearch()
        {
            IRouteMapper<object> mapper = new RouteMapper<object>();

            mapper.AddRoute(typeof(MockRoute));
            mapper.AddRoute(typeof(MockRoute2));

            Assert.True(mapper.TryGetRoute(new[] { "test" }, out var route));
            Assert.NotNull(route);

            Assert.True(mapper.TryGetRoute(new[] { "test2" }, out var nestedRoute));
            Assert.NotNull(nestedRoute);

            Assert.True(mapper.TryGetRoute(new[] { "test3", "test4" }, out var nestedRoute2));
            Assert.NotNull(nestedRoute2);

            Assert.True(mapper.TryGetRoute(new[] { "test5", "test6" }, out var route2));
            Assert.NotNull(route2);
        }

        [Test]
        public void RouteMapper_WrongReturnType()
        {
            IRouteMapper<object> mapper = new RouteMapper<object>();

            Assert.Throws<ArgumentException>(() => mapper.AddRoute(typeof(MockRoute3)));
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

    public class MockConverter : ITypeMapping<int, object>
    {
        public Task<int> MapAsync(object context, string token)
        {
            return Task.FromResult(int.Parse(token));
        }
    }
}
