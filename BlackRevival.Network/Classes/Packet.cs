namespace BlackRevival.Network.Classes;

public class Packet
{
    public ushort PacketID { get; set; }
    public ushort Size { get; set; }

    public virtual byte[] Serialize()
    {
        throw new NotImplementedException();
    }

    public virtual void Deserialize(byte[] data)
    {
        throw new NotImplementedException();
    }
    
    protected void CalculateSize(int dataSize)
    {
        Size = (ushort)(dataSize + 4); // 4 bytes for PacketID and Size fields
    }
}
