namespace ExplosiveRouting.Middleware
{
    public interface IMiddleware
    {
        IResult Run(IContext context);
    }
}
