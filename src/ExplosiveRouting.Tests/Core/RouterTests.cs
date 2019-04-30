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
    }
}
