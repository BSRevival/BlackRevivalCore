using BlackRevival.Network.Classes;

namespace BlackRevival.Network.Packets;

public class Pong : Packet
{
    public Pong()
    {
        PacketID = 1*100;
    }
    
    public ulong Tick { get; set; }
    public override void Deserialize(byte[] data)
    {
        PacketID = BitConverter.ToUInt16(data, 0);
        Size = BitConverter.ToUInt16(data, 2);
        // Deserialize additional fields based on your packet structure
        Tick = BitConverter.ToUInt64(data, 4);
    }

    public override byte[] Serialize()
    {
        CalculateSize(8);
        byte[] data = new byte[Size];
        BitConverter.GetBytes(PacketID).CopyTo(data, 0);
        BitConverter.GetBytes(Size).CopyTo(data, 2);
        BitConverter.GetBytes(Tick).CopyTo(data, 4);
        return data;
    }
}