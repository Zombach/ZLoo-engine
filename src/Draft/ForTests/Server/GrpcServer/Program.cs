using Grpc.Core;
using GrpcModels.Protos;
using GrpcServer.GrpcServices;

Console.WriteLine("Hello, World!");

var port = 9007;

var server = new Server
{
    Services = { TestGrpcService.BindService(new TestService()) },
    Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
};
server.Start();

Console.WriteLine("gRPC server listening on port " + port);
Console.ReadKey();

server.ShutdownAsync().Wait();
