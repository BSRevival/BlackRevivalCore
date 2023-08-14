using BlackRevival.Common.Model;

namespace BlackRevival.APIServer.Classes;

public class APISession
{
    public string  IPAddress { get; set; }
    public string  SessionKey { get; set; }
    public Session Session { get; set; }

    public APISession()
    {
        SessionKey = new Guid().ToString();
    }
}