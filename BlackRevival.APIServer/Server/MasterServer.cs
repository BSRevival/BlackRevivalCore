using System.Net;
using System.Net.Sockets;
using System.Text;
using BlackRevival.Network.Classes;
using BlackRevival.Network.Packets;

namespace BlackRevival.APIServer.Server;

public static class MasterServer
{
    private const int ListenPort = 42069;

    private static TcpListener listener;
    private static CancellationTokenSource cancellationTokenSource;
    private static TcpClient instanceServerClient;
    private static NetworkStream instanceServerStream;

    private static List<GameServer> gameServers;

    static MasterServer()
    {
        gameServers = new List<GameServer>();
    }

    public static async Task StartAsync()
    {
        listener = new TcpListener(IPAddress.Any, ListenPort);
        listener.Start();
        Console.WriteLine("Master Server is running");

        cancellationTokenSource = new CancellationTokenSource();

        while (!cancellationTokenSource.Token.IsCancellationRequested)
        {
            try
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                _ = Task.Run(() => HandleInstanceManagerAsync(client));
            }
            catch (SocketException)
            {
                break; // Listener stopped or canceled
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error accepting client: " + ex.Message);
            }
        }

        Console.WriteLine("Master Server is stopped");
    }

    public static void Stop()
    {
        cancellationTokenSource?.Cancel();
        listener?.Stop();
        instanceServerClient?.Close();

    }
    private static async Task<T> ReceiveResponse<T>(NetworkStream stream) where T : Packet, new()
    {
        byte[] buffer = new byte[1024];
        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
        byte[] responseData = new byte[bytesRead];
        Buffer.BlockCopy(buffer, 0, responseData, 0, bytesRead);

        T responsePacket = new T();
        responsePacket.Deserialize(responseData);

        return responsePacket;
    }


    private static async Task HandleInstanceManagerAsync(TcpClient client)
    {
        using (client)
        {
            instanceServerClient = client;
            instanceServerStream = instanceServerClient.GetStream();
            Console.WriteLine("Instance Server connected");

            byte[] buffer = new byte[1024];
            int bytesRead = await instanceServerStream.ReadAsync(buffer, 0, buffer.Length);

            Packet packet = DeserializePacket(buffer, bytesRead);

            switch (packet.PacketID)
            {
                case 1:
                    Pong pongPacket = new Pong();
                    await HandlePingPacketAsync(instanceServerStream, pongPacket);
                    Console.WriteLine("Received PONG packet: " + pongPacket.Tick);
                    break;
                case 2:
                    await HandleGetAvailableServersPacketAsync(instanceServerStream);
                    break;

                case 3:
                    await HandleStartServerRequestPacketAsync(instanceServerStream);
                    break;
                case 100:
                    await HandlePongPacketAsync(instanceServerStream);
                    break;
                default:
                    Console.WriteLine("Invalid packet ID: " + packet.PacketID);
                    break;
            }
        }
    }

    private static async Task HandlePongPacketAsync(NetworkStream networkStream)
    {
        throw new NotImplementedException();
    }

    private static Packet DeserializePacket(byte[] buffer, int bytesRead)
    {
        ushort packetID = BitConverter.ToUInt16(buffer, 0);
        ushort packetSize = BitConverter.ToUInt16(buffer, 2);

        if (packetSize != bytesRead)
            throw new InvalidOperationException("Invalid packet size");

        Packet packet;

        switch (packetID)
        {
            case 1:
                packet = new Ping() { PacketID = packetID };
                break;

            case 2:
                packet = new GetAvailableServers { PacketID = packetID };
                break;

            case 3:
                packet = new StartServerRequest { PacketID = packetID };
                break;
            case 100:
                packet = new Pong() { PacketID = packetID };
                break;

            default:
                throw new InvalidOperationException("Invalid packet ID");
        }

        return packet;
    }

    private static async Task HandlePingPacketAsync(NetworkStream stream, Pong pongPacket)
    {
        Pong responsePacket = new Pong();
        responsePacket.Tick = BitConverter.ToUInt64(Encoding.ASCII.GetBytes(DateTime.Now.Ticks.ToString()), 0);
        byte[] responseData = responsePacket.Serialize();

        pongPacket = await ReceiveResponse<Pong>(stream);
    }

    private static async Task HandleGetAvailableServersPacketAsync(NetworkStream stream)
    {
        GetAvailableServers responsePacket = new GetAvailableServers { PacketID = 2 };
        
        if (gameServers.Count > 0)
        {
            responsePacket = new GetAvailableServers
            {
                PacketID = 2,
                Servers = gameServers
            };
        }

        byte[] responseData = responsePacket.Serialize();
        await stream.WriteAsync(responseData, 0, responseData.Length);
    }
    private static StartServerRequest DeserializeStartServerRequestPacket(byte[] buffer, int bytesRead)
    {
        ushort packetID = BitConverter.ToUInt16(buffer, 0);
        ushort packetSize = BitConverter.ToUInt16(buffer, 2);

        if (packetSize != bytesRead)
            throw new InvalidOperationException("Invalid packet size");

        StartServerRequest packet = new StartServerRequest
        {
            PacketID = packetID,
            GameMode = Encoding.UTF8.GetString(buffer, 4, packetSize - 4)
        };

        return packet;
    }
    private static async Task HandleStartServerRequestPacketAsync(NetworkStream stream)
    {
        byte[] response = new byte[] { 0, 0, 0, 0 }; // Default response

        // Read the packet data
        byte[] buffer = new byte[1024];
        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
        StartServerRequest requestPacket = DeserializeStartServerRequestPacket(buffer, bytesRead);

        // Process the request and start the game server
        if (!string.IsNullOrEmpty(requestPacket.GameMode))
        {
            // Spawn a new game server instance using the provided game mode
            // Replace the following code with your logic to start the game server instance
            Console.WriteLine($"Starting game server with game mode: {requestPacket.GameMode}");

            // Simulate a response indicating success
            response = new byte[] { 1, 0, 0, 0 };
        }
        else
        {
            // Handle the case when the game mode is not provided
            Console.WriteLine("Invalid StartServerRequestPacket: Game mode not provided");
        }

        // Send the response to the Instance Server
        await stream.WriteAsync(response, 0, response.Length);
    }

    public static void AddGameServer(GameServer server)
    {
        gameServers.Add(server);
    }
    
    public static async Task SendPacketToInstanceServer(Packet packet)
    {
        if (instanceServerStream == null)
        {
            Console.WriteLine("Instance Server is not connected");
            return;
        }

        byte[] data = packet.Serialize();
        await instanceServerStream.WriteAsync(data, 0, data.Length);
    }

}
