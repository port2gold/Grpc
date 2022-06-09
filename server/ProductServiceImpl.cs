using Grpc.Core;
using Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Product.PrdouctService;

namespace server
{
    public class ProductServiceImpl : PrdouctServiceBase
    {
        public override Task<ProductMessageResponse> Product(ProductMessageRequest request, ServerCallContext context)
        {
            Int64 result = request.A * request.B;
            string message = $"The product of {request.A} and {request.B} is {result}";
            return Task.FromResult(new ProductMessageResponse { Result = result, Message = message }) ;
        }
    }
}
