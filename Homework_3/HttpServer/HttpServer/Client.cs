using System.Net.Sockets;

namespace HttpServer;

public class Client
{
    private TcpClient _client;
    
    public Client(TcpClient client)
    {
        _client = client;
    }
}