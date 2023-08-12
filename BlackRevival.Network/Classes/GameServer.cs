using System.Text;

namespace BlackRevival.Network.Classes;

public class GameServer
{
    public string RegionDomain { get; set; }
    public string Region { get; set; }
    public string IP { get; set; }

    public int GetSize()
    {
        // Calculate the size based on the string fields
        return Encoding.ASCII.GetByteCount(RegionDomain) +
               Encoding.ASCII.GetByteCount(Region) +
               Encoding.ASCII.GetByteCount(IP);
    }
}
