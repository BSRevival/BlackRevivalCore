using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using BlackRevival.Network.Classes;
using BlackRevival.Network.Packets;

namespace BlackRevival.InstanceManager.ServerManagers;

public class InstanceManagerServer
{
    private const string MasterServerAddress = "127.0.0.1";  // Replace with your Master Server IP address
    private const int MasterServerPort = 42069;

    private TcpClient masterServerClient;
    private NetworkStream stream;
    private CancellationTokenSource cancellationTokenSource;

    private List<GameServer> gameServers;

    public InstanceManagerServer()
    {
        gameServers = new List<GameServer>();
    }

    public async Task StartAsync()
    {
        await ConnectToMasterServerAsync();
        cancellationTokenSource = new CancellationTokenSource();

        // Start a background task to continuously listen for packets from the Master Server
        _ = Task.Run(async () => await ListenForPacketsAsync(cancellationTokenSource.Token));
    }

    public async Task StopAsync()
    {
        cancellationTokenSource?.Cancel();
        await masterServerClient?.GetStream().WriteAsync(new byte[0], 0, 0); // Send an empty message to unblock the listener
        masterServerClient?.Close();
    }

    private async Task ConnectToMasterServerAsync()
    {
        masterServerClient = new TcpClient();
        await masterServerClient.ConnectAsync(MasterServerAddress, MasterServerPort);
        stream = masterServerClient.GetStream();
        Console.WriteLine("Connected to Master Server");
    }

    private async Task ListenForPacketsAsync(CancellationToken cancellationToken)
    {
        byte[] buffer = new byte[1024];

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
                if (bytesRead == 0)
                    break; // Connection closed by the Master Server

                Packet packet = DeserializePacket(buffer, bytesRead);

                switch (packet.PacketID)
                {
                    case 1:
                        await HandlePingPacketAsync();
                        break;

                    case 2:
                        await HandleGetAvailableServersPacketAsync((GetAvailableServers)packet);
                        break;

                    case 3:
                        await HandleStartServerRequestPacketAsync((StartServerRequest)packet);
                        break;

                    default:
                        Console.WriteLine("Invalid packet ID: " + packet.PacketID);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading packet: " + ex.Message);
                break;
            }
        }

        Console.WriteLine("Disconnected from Master Server");
    }

    private Packet DeserializePacket(byte[] buffer, int bytesRead)
    {
        ushort packetID = BitConverter.ToUInt16(buffer, 0);
        ushort packetSize = BitConverter.ToUInt16(buffer, 2);

        if (packetSize != bytesRead)
            throw new InvalidOperationException("Invalid packet size");

        Packet packet;

        switch (packetID)
        {
            case 1:
                packet = new Packet { PacketID = packetID };
                break;

            case 2:
                packet = DeserializeGetAvailableServersPacket(buffer, packetSize);
                break;

            case 3:
                packet = DeserializeStartServerRequestPacket(buffer, packetSize);
                break;

            default:
                throw new InvalidOperationException("Invalid packet ID");
        }

        return packet;
    }

    private GetAvailableServers DeserializeGetAvailableServersPacket(byte[] buffer, int packetSize)
    {
        GetAvailableServers packet = new GetAvailableServers { PacketID = BitConverter.ToUInt16(buffer, 0) };
        int serverCount = BitConverter.ToInt32(buffer, 4);

        if (packetSize - 8 != serverCount * packet.Servers[0].GetSize())
            throw new InvalidOperationException("Invalid packet size");

        packet.Servers = new List<GameServer>();

        int offset = 8;
        for (int i = 0; i < serverCount; i++)
        {
            GameServer server = new GameServer
            {
                RegionDomain = ReadNullTerminatedString(buffer, ref offset),
                Region = ReadNullTerminatedString(buffer, ref offset),
                IP = ReadNullTerminatedString(buffer, ref offset)
            };
            packet.Servers.Add(server);
        }

        return packet;
    }

    private StartServerRequest DeserializeStartServerRequestPacket(byte[] buffer, int packetSize)
    {
        StartServerRequest packet = new StartServerRequest { PacketID = BitConverter.ToUInt16(buffer, 0) };

        int gameModeSize = packetSize - 4;
        packet.GameMode = Encoding.ASCII.GetString(buffer, 4, gameModeSize);

        return packet;
    }

    private string ReadNullTerminatedString(byte[] buffer, ref int offset)
    {
        int startOffset = offset;
        while (offset < buffer.Length && buffer[offset] != 0)
            offset++;

        string str = Encoding.ASCII.GetString(buffer, startOffset, offset - startOffset);
        offset++; // Skip the null terminator
        return str;
    }

    private async Task HandlePingPacketAsync()
    {
        Pong responsePacket = new Pong();
        responsePacket.Tick = BitConverter.ToUInt64(Encoding.ASCII.GetBytes(DateTime.Now.Ticks.ToString()), 0);
        byte[] responseData = responsePacket.Serialize();

        await stream.WriteAsync(responseData, 0, responseData.Length);
    }

    private async Task HandleGetAvailableServersPacketAsync(GetAvailableServers packet)
    {
        if (gameServers.Count > 0)
        {
            packet.Servers = gameServers;
        }
        else
        {
            packet.Servers = new List<GameServer>();
        }

        byte[] responseData = packet.Serialize();
        await SendPacketAsync(responseData);
    }

    private async Task HandleStartServerRequestPacketAsync(StartServerRequest packet)
    {
        string gameMode = packet.GameMode;
        string currentDirectory = Environment.CurrentDirectory;
        string gameServerPath = $"{currentDirectory}\\GameServer.exe";
        string commandLineArgs = GetCommandLineArgsForGameMode(gameMode);

        Process.Start(gameServerPath, commandLineArgs);
    }

    private string GetCommandLineArgsForGameMode(string gameMode)
    {
        // Define your logic to determine the command line arguments based on the game mode
        // For simplicity, this example uses a switch statement
        switch (gameMode)
        {
            case "mode1":
                return "127.0.0.1 27900";

            case "mode2":
                return "arg3 arg4";

            default:
                return string.Empty;
        }
    }

    private async Task SendPacketAsync(byte[] packetData)
    {
        await stream.WriteAsync(packetData, 0, packetData.Length);
    }

    public void AddGameServer(GameServer server)
    {
        gameServers.Add(server);
    }
}


