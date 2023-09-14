using Serilog;

namespace BlackRevival.GameServer;

class Program
{
    private const string InstanceManagerAddress = ""; // Replace with your Instance Manager IP address
    private const int InstanceManagerPort = 42069;
    
    static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Console()
            .Enrich.FromLogContext()
            .CreateLogger();

        Server gameServer = new Server();
        
        await gameServer.StartAsync(args[0], args[1]);
        
        // Keep the server running until a key is pressed
        Console.WriteLine("Game Server is running. Press any key to stop.");
        Console.ReadKey();
    }

}