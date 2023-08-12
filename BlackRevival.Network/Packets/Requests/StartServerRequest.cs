using System.Text;
using BlackRevival.Network.Classes;

namespace BlackRevival.Network.Packets;

public class StartServerRequest : Packet
{
    public string GameMode { get; set; }

    public override byte[] Serialize()
    {
        byte[] gameModeBytes = Encoding.ASCII.GetBytes(GameMode);
        CalculateSize(gameModeBytes.Length);

        byte[] data = new byte[Size];
        BitConverter.GetBytes(PacketID).CopyTo(data, 0);
        BitConverter.GetBytes(Size).CopyTo(data, 2);
        gameModeBytes.CopyTo(data, 4);

        return data;
    }
}