using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace QueueDemo
{
    public class Function1
    {
        //NOTE:
        //REMEBER TO UPDATE THE NuGET PACKAGES!!

        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("QueueDemo")]
        public void Run([QueueTrigger("myqueue", Connection = "Default")] QueueMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
        }
    }
}
