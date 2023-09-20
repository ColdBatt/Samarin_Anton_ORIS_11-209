namespace HttpServer;

public class StaticManager
{
    private string _path;
    public StaticManager()
    {
        if (!Directory.Exists(@".\static"))
        {
            Directory.CreateDirectory(@".\static");
        }

        _path = @".\static\index.html";
    }

    public byte[] GetPage(string? file = null)
    {
        var path = _path;
        if (file != null)
            _path = file;

        return File.ReadAllBytes(path);
    }
    
}