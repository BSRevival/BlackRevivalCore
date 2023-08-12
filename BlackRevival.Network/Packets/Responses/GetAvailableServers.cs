using System.Text;
using BlackRevival.Network.Classes;

namespace BlackRevival.Network.Packets;

public class GetAvailableServers : Packet
{
    public int ServerCount { get; set; }
    public List<GameServer> Servers { get; set; }
   
    public override void Deserialize(byte[] data)
    {
        PacketID = BitConverter.ToUInt16(data, 0);
        Size = BitConverter.ToUInt16(data, 2);
        // Deserialize additional fields based on your packet structure
        int offset = 4;
        ServerCount = BitConverter.ToInt32(data, offset);
        offset += 4;

        Servers = new List<GameServer>();
        for (int i = 0; i < ServerCount; i++)
        {
            GameServer server = new GameServer();
            int regionDomainLength = BitConverter.ToInt32(data, offset);
            offset += 4;
            server.RegionDomain = Encoding.UTF8.GetString(data, offset, regionDomainLength);
            offset += regionDomainLength;

            // Deserialize additional fields for GameServer

            Servers.Add(server);
        }
    }

    public override byte[] Serialize()
    {
        CalculateSize(CalculateDataSize());

        byte[] data = new byte[Size];
        BitConverter.GetBytes(PacketID).CopyTo(data, 0);
        BitConverter.GetBytes(Size).CopyTo(data, 2);

        if (Servers != null && Servers.Count > 0)
        {
            BitConverter.GetBytes(Servers.Count).CopyTo(data, 4);

            int offset = 8;
            foreach (GameServer server in Servers)
            {
                byte[] regionDomainBytes = Encoding.ASCII.GetBytes(server.RegionDomain);
                byte[] regionBytes = Encoding.ASCII.GetBytes(server.Region);
                byte[] ipBytes = Encoding.ASCII.GetBytes(server.IP);

                regionDomainBytes.CopyTo(data, offset);
                regionBytes.CopyTo(data, offset + regionDomainBytes.Length);
                ipBytes.CopyTo(data, offset + regionDomainBytes.Length + regionBytes.Length);

                offset += regionDomainBytes.Length + regionBytes.Length + ipBytes.Length;
            }
        }
        else
        {
            BitConverter.GetBytes(0).CopyTo(data, 4);
        }

        return data;
    }

    private int CalculateDataSize()
    {
        if (Servers != null && Servers.Count > 0)
        {
            int serverSize = Servers[0].GetSize();
            return Servers.Count * serverSize;
        }

        return 0;
    }
}
