using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace HttpTriggerStringToQueue
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        //QueueOutput attribute compilation errors?
        //install-package Microsoft.Azure.Functions.Worker.Extensions.Storage.Queues via NuGet - Package Manager Console


        [Function("Function1")]
        [QueueOutput("test-myqueue-items")]
        public static List<string> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            return new List<string> { "hello there" };
        }
    }
}
