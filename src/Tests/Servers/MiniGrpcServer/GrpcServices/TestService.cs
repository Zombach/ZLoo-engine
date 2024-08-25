using Grpc.Core;
using GrpcModels.Protos;

namespace MiniGrpcServer.GrpcServices;

public class TestService : TestGrpcService.TestGrpcServiceBase
{
    public override async Task<Response> TestConnected(Request request, ServerCallContext context)
    {
        Console.WriteLine(request.Name);
        await Task.Delay(1000);
        return new Response { Message = string.Join("", request.Name.Reverse()) };
    }
}