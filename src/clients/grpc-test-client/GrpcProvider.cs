using Grpc.Core;
using Grpc.Models.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Grpc.Test.Client;

public class GrpcProvider : IDisposable
{
    private readonly Channel _channel;
    private readonly TestGrpcService.TestGrpcServiceClient _client;

    public GrpcProvider(IOptions<GrpcOptions> options, IConfiguration config)
    {
        _channel = new Channel("127.0.0.1", 9007, ChannelCredentials.Insecure);
        _client = new TestGrpcService.TestGrpcServiceClient(_channel);
    }

    public async Task<Response> Send(string message)
    {
        var response = await _client.TestConnectedAsync(new Request { Name = message });

        return response;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            _channel.ShutdownAsync().Wait();
        }
    }
}
