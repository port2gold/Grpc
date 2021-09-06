using Grpc.Core;
using Product;
using Sum;
using System;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        const string target = "127.0.0.1:50052";
        static void Main(string[] args)
        {
            Channel channel = new Channel(target, ChannelCredentials.Insecure);

            channel.ConnectAsync().ContinueWith((task) =>
            {
                if(task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("The client connected successfully");
            });

            var client = new SumService.SumServiceClient(channel);
            var clientProduct = new PrdouctService.PrdouctServiceClient(channel); 

            var sumRequest = new SumMessageRequest
            {
                FirstNumber = 12,
                SecondNumber = 40
            };
            var productRequest = new ProductMessageRequest
            {
                A = 20,
                B = 60
            };
            var resultProduct = clientProduct.Product(productRequest);
            var result = client.Sum(sumRequest);
            Console.WriteLine(result.Result);
            Console.WriteLine(result.Message);

            Console.WriteLine(resultProduct);
            Console.WriteLine(result.Message);
            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }
    }
}
