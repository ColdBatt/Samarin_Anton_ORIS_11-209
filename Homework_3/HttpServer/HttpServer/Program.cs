using System.Net;
using System.Text;
using System.Text.Json;
using HttpListenerLesson.Configuration;
using HttpServer;


public static class Program
{
    private const string SettingsPath = @"./appsettings.json";
    public static void Main(string[] args)
    {
        try
        {
            Configurator.UpdateConfig(SettingsPath);
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine($"File {SettingsPath} not found");
        }
        finally
        {
            var server = new HttpServer.HttpServer();
            server.Start();
        }
    }
}








