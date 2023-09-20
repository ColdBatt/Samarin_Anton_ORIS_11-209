using System.Net;
using static HttpServer.Configurator;


namespace HttpServer;

public class HttpServer
{
    private HttpListener _server;
    private StaticManager _manager;
    public HttpServer()
    {
        _manager = new StaticManager();
        _server = new HttpListener();
        _server.Prefixes.Add($"https://{Config.Address}:{Config.Port}/connection/");
    }

    public void Start()
    {
        Console.WriteLine("Starting server...");
        _server.Start();
        Listen();
        Console.WriteLine("Server started...");
    }

    public void Stop()
    {
        _server.Close();
    }

    async void Listen()
    {
        while (true)
        {
            var context = await _server.GetContextAsync();
            Console.WriteLine(context.Request);
            await Task.Run(() =>
                {
                    var response = context.Response;
                    var page = _manager.GetPage();
                    response.ContentLength64 = page.Length;
                    var output = response.OutputStream;
                    output.WriteAsync(page);
                    output.FlushAsync();
                }
            );
            Thread.Sleep(20000);
        }
    }
    
    /*
    AppSetting? config;
    using (var file = File.OpenRead(@".\appsettings.json"))
    {
        config = JsonSerializer.Deserialize<AppSetting>(file) ?? throw new Exception();
    }

    var server = new HttpListener();
    server.Prefixes.Add($"http://{config.Address}:{config.Port}/connection/");

    Console.WriteLine("Start server...");
    server.Start();
    Console.WriteLine("Server started...");


    var context = await server.GetContextAsync();
    var url = context.Request.Url;
    var path = "static" + url.AbsolutePath;
    var response = context.Response;

    var buffer = File.ReadAllBytes(@"./static/tanki.html");
    response.ContentLength64 = buffer.Length;

    var output = response.OutputStream;
    await output.WriteAsync(buffer);
    await output.FlushAsync();


    Console.WriteLine("Request handled...");
    */


}