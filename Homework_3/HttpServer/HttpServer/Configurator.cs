using System.Text.Json;
using System.Text.Json.Nodes;
using HttpListenerLesson.Configuration;

namespace HttpServer;

public static class Configurator
{
    private static AppSetting? _config;
    public static AppSetting? Config {
        get
        {
            if (_config == null)
                throw new NullReferenceException("Config is not updated yet");
            return _config;
        }
    }
    
    public static void UpdateConfig(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"Configuration file not found path: {path}");
        
        using var file = File.OpenRead(path);
        _config = JsonSerializer.Deserialize<AppSetting>(file);
    }
}