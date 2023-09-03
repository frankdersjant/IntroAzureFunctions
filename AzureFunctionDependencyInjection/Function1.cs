using System.Net;
using AzureFunctionDependencyInjection.DAL;
using AzureFunctionDependencyInjection.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionDependencyInjection
{
    public class Function1
    {
        private readonly ILogger _logger;
        private readonly IFakeProductDB _fakeProductDB;

        public Function1(ILoggerFactory loggerFactory, IFakeProductDB fakeProductDB)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
            _fakeProductDB = fakeProductDB;
        }

        [Function("DepInject")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            IEnumerable<Product> products = _fakeProductDB.GetProducts();


            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString(products.First().ProductName + DateTime.Now);



            return response;
        }
    }
}
