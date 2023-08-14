using BlackRevival.APIServer.Classes;

namespace BlackRevival.APIServer.Middleware;

public class SessionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly SessionManager _sessionManager;

    public SessionMiddleware(RequestDelegate next, SessionManager sessionManager)
    {
        _next = next;
        _sessionManager = sessionManager;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var ipAddress = context.Connection.RemoteIpAddress?.ToString();
        if (!string.IsNullOrEmpty(ipAddress))
        {
            var session = _sessionManager.StartOrGetSession(ipAddress);
            context.Items["Session"] = session;
        }

        // Call the next middleware in the pipeline
        await _next(context);
    }

}