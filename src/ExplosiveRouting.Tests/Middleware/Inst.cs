using ExplosiveRouting.Core.Middleware;
using ExplosiveRouting.Core;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace ExplosiveRouting.Tests.Middleware
{
    [TestFixture]
    public class Inst
    {
        /*
        static IContext Context = new DemoContext();

        [Test]
        public void Factory()
        {
            var middleware = MiddlewareFactory.CreateMiddleware(typeof(DemoMiddleware));
            Assert.IsInstanceOf<IMiddleware>(middleware);
            Assert.IsInstanceOf<ISuccessResult>(middleware.Run(Context));
        }

        [Test]
        public void GenericFactory()
        {
            var middleware = MiddlewareFactory.CreateMiddleware<DemoMiddleware>();
            Assert.IsInstanceOf<IMiddleware>(middleware);
            Assert.IsInstanceOf<ISuccessResult>(middleware.Run(Context));
        }

        [Test]
        public async Task AsyncFactory()
        {
            var middleware = MiddlewareFactory.CreateAsyncMiddleware(typeof(DemoAsyncMiddleware));
            Assert.IsInstanceOf<IAsyncMiddleware>(middleware);
            Assert.IsInstanceOf<ISuccessResult>(await middleware.RunAsync(Context));
        }

        [Test]
        public async Task GenericAsyncFactory()
        {
            var middleware = MiddlewareFactory.CreateAsyncMiddleware<DemoAsyncMiddleware>();
            Assert.IsInstanceOf<IAsyncMiddleware>(middleware);
            Assert.IsInstanceOf<ISuccessResult>(await middleware.RunAsync(Context));
        }

        [Test]
        public void InjectedFactory()
        {
            var middleware = MiddlewareFactory.CreateMiddleware<DemoInjectedMiddleware>(options =>
            {
                options.ServiceProvider = new ServiceCollection()
                    .AddSingleton<Random>()
                    .BuildServiceProvider();
            });
            Assert.IsInstanceOf<ISuccessResult>(middleware.Run(Context));
        }

        [Test]
        public void Configure()
        {
            Assert.IsNotNull(MiddlewareFactory.Configure(options => {
            }));
        }
        */
    }
}
