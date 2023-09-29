namespace HttpServer;

public class Page
{
    public byte[] Content { get; private set; }
    public int Length => Content.Length;
    public string ContentType { get; private set; }

    public Page(byte[] content, string contentType)
    {
        ContentType = contentType;
        Content = content;
    }
}