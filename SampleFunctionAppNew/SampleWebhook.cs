using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SampleFunctionAppNew
{
    public static class SampleWebhook
    {
        [FunctionName("SampleWebhook")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function,"post", Route = null)] HttpRequest req,
            [Queue("sample-update-record"),StorageAccount("AzureWebjobsstorage")] ICollector<string> msg,ILogger log)
        {

            log.LogInformation("webhook prceessed a request.");
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
