using ExplosiveRouting.Core;

namespace ExplosiveRouting.Core.Middleware
{
    /// <summary>
    /// A singleton container returning results to the caller.
    /// </summary>
    public interface IMiddleware
    {
        IResult Run(IContext context);
    }
}
