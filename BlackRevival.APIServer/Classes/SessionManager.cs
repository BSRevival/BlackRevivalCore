namespace BlackRevival.APIServer.Classes;

public class SessionManager
{
    private readonly Dictionary<string, APISession> _sessions;
    
    public SessionManager()
    {
        _sessions = new Dictionary<string, APISession>();
    }
    
    public APISession StartOrGetSession(string ipAddress)
    {
        if (!_sessions.TryGetValue(ipAddress, out var session))
        {
            session = new APISession { IPAddress = ipAddress };
            _sessions.Add(ipAddress, session);
        }
        return session;
    }

    public APISession GetSessionByIPAddress(string ipAddress)
    {
        _sessions.TryGetValue(ipAddress, out var session);
        return session;
    }
    
    public bool EndSession(string ipAddress)
    {
        return _sessions.Remove(ipAddress);
    }


}