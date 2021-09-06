using Grpc.Core;
using Sum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Sum.SumService;

namespace server
{
    public class SumServiceImpl : SumServiceBase
    {
        public override Task<SumMessageResponse> Sum(SumMessageRequest request, ServerCallContext context)
        {
            Int32 result = request.FirstNumber + request.SecondNumber;
            string message = $"The sum of {request.FirstNumber} and {request.SecondNumber} is {result}";
            return Task.FromResult(new SumMessageResponse { Result = result, Message = message}) ;
        }
    }
}
