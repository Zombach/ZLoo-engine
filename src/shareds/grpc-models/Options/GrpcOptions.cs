namespace Grpc.Models.Options
{
    public class GrpcOptions
    {
        public const string SectionKey = nameof(GrpcOptions);

        public string Host { get; set; } = "127.0.0.1";
        public int Port { get; set; } = 9007;
    }
}
