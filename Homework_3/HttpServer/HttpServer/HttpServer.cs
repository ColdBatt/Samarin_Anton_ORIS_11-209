using System.Net;
using static HttpServer.Configurator;


namespace HttpServer;

public class HttpServer
{
    private HttpListener _listener;
    private StaticManager _manager;
    public HttpServer()
    {
        _manager = new StaticManager();
        _listener = new HttpListener();
        _listener.Prefixes.Add($"http://{Config.Address}:{Config.Port}/");
    }

    public async Task StartAsync()
    {
        Console.WriteLine("Starting server...");
        _listener.Start();
        Console.WriteLine($"Server started on port: {Config.Port}");
        await ListenAsync();
    }

    public void Stop()
    {
        _listener.Close();
    }

    private async Task ListenAsync()
    {
        while (true)
        {
            var context = await _listener.GetContextAsync();
            Console.WriteLine(context.Request);
            
            var url = context.Request.Url;
            var response = context.Response;
            var page = _manager.GetPage(url);
            
            response.ContentType = page.ContentType;
            var output = response.OutputStream;
            response.ContentLength64 = page.Length;
            await output.WriteAsync(page.Content);
            await output.FlushAsync();
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