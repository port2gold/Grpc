using Grpc.Core;
using System;
using System.IO;

namespace server
{
    class Program
    {
        const int port = 50052;
        static void Main(string[] args)
        {
            Server server = null;

            try
            {
                server = new Server
                {
                    Services = { Sum.SumService.BindService(new SumServiceImpl())},
                    Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
                };
                server.Start();
                Console.WriteLine($"The server is listening on port {port}");
                Console.ReadKey();
            }
            catch (IOException e)
            {

                Console.WriteLine($"The server failed to start {e.Message}");
            }
            finally
            {
                if (server != null)
                    server.ShutdownAsync().Wait();
            }
        }
    }
}
