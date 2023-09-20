using System.Text.Json;
using System.Text.Json.Nodes;
using HttpListenerLesson.Configuration;

namespace HttpServer;

public static class Configurator
{
    public static AppSetting? Config { get; private set; }
    
    public static void UpdateConfig(string path)
    {
        using var file = File.OpenRead(path);
        Config = JsonSerializer.Deserialize<AppSetting>(file);
    }
}