using System.Net;
using HttpTriggerOutputToQueue.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HttpTriggerOutputToQueue
{
    public class Function1
    {
        //NOTE: for the QueueOutput attribute to work, you need to install the following NuGet package:
        //install-package Microsoft.Azure.Functions.Worker.Extensions.Storage.Queues 

        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Seri")]
        [QueueOutput("CustomerOutput", Connection = "AzureWebJobsStorage")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            string requestBody = string.Empty;
            using (StreamReader reader = new StreamReader(req.Body))
            {
                requestBody = reader.ReadToEnd();
            };

            Customer customerdata = JsonConvert.DeserializeObject<Customer>(requestBody);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString(customerdata.Name + ' ' + DateTime.Now);

            return response;
        }
    }
}
