using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ExplosiveRouting.Core;

namespace ExplosiveRouting.Core.Middleware
{
    public static class MiddlewareFactory
    {
        private static IMiddlewareOptions Options { get; set; }

        private static SemaphoreSlim OptionsSynchronizer = new SemaphoreSlim(1, 1);

        static MiddlewareFactory()
        {
            Options = new MiddlewareOptions();
        }

        public static IMiddlewareOptions Configure(Action<IMiddlewareOptions> configureOptions)
        {
            var options = new MiddlewareOptions();

            try
            {
                OptionsSynchronizer.Wait();
                Options = options;
                return Options;
            }
            finally
            {
                OptionsSynchronizer.Release();
            }
        }

        public static IMiddleware CreateMiddleware<T>(Action<IMiddlewareOptions> configureOptions = null) 
            where T : IMiddleware
        {
            var options = Options;
            if (configureOptions != null)
            {
                options = new MiddlewareOptions();
                configureOptions(options);
            }

            return typeof(T).CreateInstanceOf<T>(options.ServiceProvider);
        }

        public static IMiddleware CreateMiddleware(Type type, Action<IMiddlewareOptions> configureOptions = null)
        {
            var options = Options;
            if (configureOptions != null)
            {
                options = new MiddlewareOptions();
                configureOptions(options);
            }
            return type.CreateInstanceOf<IMiddleware>(options.ServiceProvider);
        }

        public static IAsyncMiddleware CreateAsyncMiddleware<T>(Action<IMiddlewareOptions> configureOptions = null)
            where T : IAsyncMiddleware
        {
            var options = Options;
            if (configureOptions != null)
            {
                options = new MiddlewareOptions();
                configureOptions(options);
            }

            return typeof(T).CreateInstanceOf<IAsyncMiddleware>(options.ServiceProvider);
        }

        public static IAsyncMiddleware CreateAsyncMiddleware(Type type, Action<IMiddlewareOptions> configureOptions = null)
        {
            var options = Options;
            if (configureOptions != null)
            {
                options = new MiddlewareOptions();
                configureOptions(options);
            }
            return type.CreateInstanceOf<IAsyncMiddleware>(options.ServiceProvider);
        }
    }
}
