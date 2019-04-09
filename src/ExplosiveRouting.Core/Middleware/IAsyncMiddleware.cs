using System.Threading.Tasks;

namespace ExplosiveRouting.Core.Middleware
{
    /// <summary>
    /// A transient container returning results to the caller asynchronously.
    /// </summary>
    public interface IAsyncMiddleware<TContext>
    {
        Task<IResult> RunAsync(TContext context);
    }
}
