namespace BlackRevival.Common.Auth;

public class AuthRequest
{
    public AuthProvider authProvider { get; set; }
    public long userNum { get; set; }
    public string machineNum { get; set; }
    public string userId { get; set; }
}