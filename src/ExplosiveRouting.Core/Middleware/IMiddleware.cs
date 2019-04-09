using ExplosiveRouting.Core;

namespace ExplosiveRouting.Core.Middleware
{
    /// <summary>
    /// A singleton container returning results to the caller.
    /// </summary>
    public interface IMiddleware<TContext>
    {
        IResult Run(TContext context);
    }
}
