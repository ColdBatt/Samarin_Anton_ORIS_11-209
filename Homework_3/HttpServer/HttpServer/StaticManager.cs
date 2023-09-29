namespace HttpServer;

public class StaticManager
{
    private string _defaultPath;
    public StaticManager()
    {
        if (!Directory.Exists(@".\static"))
            Directory.CreateDirectory(@".\static");
        
        _defaultPath = @".\static\index.html";
    }

    public Page GetPage(Uri uri)
    {
        Console.WriteLine(uri.AbsolutePath);
        var absolutePath = CheckAndGetCorrectPath("./static" + uri.AbsolutePath);
        
        
        return new Page(File.ReadAllBytes(absolutePath),
            GetContentType(GetExtensionFromPath(absolutePath)));
    }

    private string CheckAndGetCorrectPath(string path)
    {
        if (path == "./")
            return !File.Exists(path) ? "./not_found/not_found.html" : _defaultPath;
        
        return !File.Exists(path) ? "./not_found/not_found.html" : path;
    }

    private string GetExtensionFromPath(string path) =>
        path[path.LastIndexOf(".", StringComparison.Ordinal)..];
    
    private string GetContentType(string fileExtension)
    {
        return fileExtension switch
        {
            ".css" => "text/css",
            ".html" => "text/html",
            ".png" => "images/image",
            ".jpg" => "images/jpeg",
            ".svg" => "images/image",
            ".ico" => "images/image"
        };
    }
    
}