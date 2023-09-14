using BlackRevival.InstanceManager.ServerManagers;

class Program
{
    static async Task Main()
    {
        
        InstanceManagerServer instanceManagerServer = new InstanceManagerServer();
        
        await instanceManagerServer.StartAsync();

        // Keep the server running until a key is pressed
        Console.WriteLine("Instance Manager Server is running. Press any key to stop.");
        Console.ReadKey();

        await instanceManagerServer.StopAsync();
    }
}