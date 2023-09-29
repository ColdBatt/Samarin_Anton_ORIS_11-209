using System.Net;
using System.Text;
using System.Text.Json;
using HttpListenerLesson.Configuration;
using HttpServer;


public static class Program
{
    static void Main(string[] args)
    {
        var serverController = new ServerController();
        serverController.StartServer();
        serverController.Dispose();
    }
}








