using ExplosiveRouting.Discovery;
using ExplosiveRouting.Extensions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExplosiveRouting.Tests.Core
{
    [TestFixture]
    public class TypeMapperTests
    {
        private readonly IServiceCollection _services = new ServiceCollection();

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

            mapper.AddMapping(typeof(MockConverter), _services);

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

            mapper.AddMapping(Assembly.GetAssembly(typeof(MockConverter)), _services);

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

            Assert.Throws<ArgumentException>(() => mapper.AddMapping(typeof(object), _services));
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
