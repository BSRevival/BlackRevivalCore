using BlackRevival.APIServer.Middleware;

public static class SessionMiddlewareExtensions
{
    public static IApplicationBuilder UseSessionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SessionMiddleware>();
    }
}