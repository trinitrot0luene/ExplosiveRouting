using ExplosiveRouting.Shared;

namespace ExplosiveRouting.Middleware
{
    public enum ExecutionMode
    {
        /// <summary>
        /// Middleware will be run sequentially, and returned <see cref="IResult"/>s checked individually.
        /// </summary>
        Sequential,

        /// <summary>
        /// Middleware will be run concurrently, and returned <see cref="IResult"/>s will be wrapped into an <see cref="AggregateResult"/>.
        /// </summary>
        Concurrent
    }
}