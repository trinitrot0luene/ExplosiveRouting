using System.Threading.Tasks;

namespace ExplosiveRouting.Middleware
{
    public interface IAsyncMiddleware
    {
        Task<IResult> RunAsync(IContext context);
    }
}
