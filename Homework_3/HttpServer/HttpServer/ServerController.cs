namespace HttpServer;


public class ServerController: IDisposable
{
    private const string ServerConfigurationPath = @".\appsettings.json";
    
    private HttpServer _httpServer;
    

    public void StartServer()
    {
        Console.WriteLine();
        try
        {
            Configurator.UpdateConfig(ServerConfigurationPath);
            _httpServer = new HttpServer();
            _httpServer.StartAsync().Wait();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Server Stopped...");
        }
    }
    
    public void Dispose() => _httpServer.Stop();
}