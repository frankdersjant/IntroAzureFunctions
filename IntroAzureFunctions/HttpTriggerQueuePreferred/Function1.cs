using System.Net;
using System.Text.Json;
using HttpTriggerQueuePreferred.Model;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace HttpTriggerQueuePreferred
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Function1")]
        public CustumOutputType Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            string requestBody = String.Empty;

            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                requestBody = streamReader.ReadToEnd();
            }
            Customer customerdata = JsonSerializer.Deserialize<Customer>(requestBody);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            return new CustumOutputType
            {

                Name = customerdata.Name,
                HttpResponse = response
            };
        }

        public class CustumOutputType
        {
            [QueueOutput("testque")]
            public string Name { get; set; }
            public HttpResponseData HttpResponse { get; set; }
        }
    }
}
