using System;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcModels.Protos;

namespace GrpcClient;

public class GrpcProvider : IDisposable
{
    private readonly Channel _channel;
    private readonly TestGrpcService.TestGrpcServiceClient _client;

    public GrpcProvider()
    {
        _channel = new Channel("127.0.0.1:9007", ChannelCredentials.Insecure);
        _client = new TestGrpcService.TestGrpcServiceClient(_channel);
    }

    public async Task<Response> Send(string message)
    {
        var response = await _client.TestConnectedAsync(new Request { Name = message });

        return response;
    }

    public void Dispose()
    {
        _channel.ShutdownAsync().Wait();
    }
}
