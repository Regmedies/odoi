using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using WebhookFunctionApp2.Helper;

namespace WebhookFunctionApp2
{
    public static class UpdateRecord2

    {
        private static readonly RestClient client = new RestClient($"https://api.tadabase.io/api/v1/data-tables/{GetEnvironmentVariable("UpdateTableId")}/records")
        {
            Timeout = -1
        };

    [FunctionName("UpdateRecord2")]
        public static void Run([QueueTrigger("update-record2", Connection = "AzureWebJobsStorage")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
        private static string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
