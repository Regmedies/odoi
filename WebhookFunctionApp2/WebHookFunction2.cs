using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebhookFunctionApp2
{
    public static class WebHookFunction2
    {
        [FunctionName("WebHookFunction2")]
        public static async Task<IActionResult> Run(
            //[HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [HttpTrigger(AuthorizationLevel.Function,"post", Route = null)] HttpRequest req,
            [Queue("update-record"),StorageAccount("AzureWebJobsStorage")]ICollector<string> msg, ILogger log)
        {
            log.LogInformation("Webhook processed a request");
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            try
            {
                msg.Add(requestBody);
                return new OkResult();
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}
