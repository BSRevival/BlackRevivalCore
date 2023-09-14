using System.Text;
using BlackRevival.Network.Classes;

namespace BlackRevival.Network.Packets;

public class RequestPingServers: Packet
{

    public override byte[] Serialize()
    {
        CalculateSize(0);
        byte[] data = new byte[Size];
        BitConverter.GetBytes(PacketID).CopyTo(data, 0);
        BitConverter.GetBytes(Size).CopyTo(data, 2);
        return data;

    }
}