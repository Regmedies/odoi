using System;
using System.Globalization;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using RestSharp;
using SampleFunctionAppNew.Helper;
using SampleFunctionAppNew.Models;

namespace SampleFunctionAppNew
{
    public static class SampleUpdateRecord
    {
        private static readonly RestClient Client = new RestClient($"https://api.tadabase.io/api/v1/data-table/{GetEnvironmentVariable("updateTableId")}/records")
        {
            Timeout = -1
        };

        [FunctionName("SampleUpdateRecord")]
        public static void Run([QueueTrigger("sample-update-record", Connection = "AzureWebJobsStorage")]string record, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {record}");

            var parametersDictionary = QueryStringHelper.QueryStringToDict(record);
            var jsonString = JsonConvert.SerializeObject(parametersDictionary);
            var updateMessage = JsonConvert.DeserializeObject<UpdateWebhookMessage>(jsonString);

            if (updateMessage.Join.Count == 0)
            {
                return;
            }
            var updateModel = new UpdateModel
            {
                LongText = $"function run successfully {DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)}"
            };

            var request = new RestRequest(updateMessage.Join.First().Value, Method.POST);
            request.AddHeader("X-Tadabase-App-id", $"{GetEnvironmentVariable("AppId")}");
            request.AddHeader("X-Tadabase-App-Key", $"{GetEnvironmentVariable("AppKey")}");
            request.AddHeader("X-Tadabase-App-Secret", $"{GetEnvironmentVariable("AppSecret")}");
            request.AlwaysMultipartFormData = true;
            RestSharpHelper.AddParameter(updateModel, request);

            IRestResponse response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                log.LogInformation($"The record updated successfully.Api Response: {response.Content}");
            }
            else
            {
                log.LogError(response.Content);

                if (response.ErrorException != null)
                {
                    throw new Exception(response.ErrorMessage, response.ErrorException);
                }
            }
        }
       private static string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
