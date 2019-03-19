using System;
using System.Collections.Generic;
using System.Text;

namespace ExplosiveRouting.Shared.Middleware
{
    /// <summary>
    /// Configuration options for <see cref="IAsyncMiddleware"/> and <see cref="IMiddleware"/>.
    /// </summary>
    public interface IMiddlewareOptions
    {
        /// <summary>
        /// Gets or sets the services to be injected into the middleware on instantiation.
        /// </summary>
        IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ExecutionMode"/> of the middleware.
        /// </summary>
        ExecutionMode ExecutionMode { get; set; }
    }
}
