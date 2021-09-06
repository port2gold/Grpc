using Grpc.Core;
using Sum;
using System;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        const string target = "127.0.0.1:50051";
        static void Main(string[] args)
        {
            Channel channel = new Channel(target, ChannelCredentials.Insecure);

            channel.ConnectAsync().ContinueWith((task) =>
            {
                if(task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("The client connected successfully");
            });

            var client = new SumService.SumServiceClient(channel);

            var sumRequest = new SumMessageRequest
            {
                FirstNumber = 12,
                SecondNumber = 40
            };

            var result = client.Sum(sumRequest);
            Console.WriteLine(result.Result);
            Console.WriteLine(result.Message);
            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }
    }
}
