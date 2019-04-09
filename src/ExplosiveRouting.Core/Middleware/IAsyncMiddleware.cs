using System.Threading.Tasks;

namespace ExplosiveRouting.Core.Middleware
{
    /// <summary>
    /// A transient container returning results to the caller asynchronously.
    /// </summary>
    public interface IAsyncMiddleware
    {
        Task<IResult> RunAsync(IContext context);
    }
}
