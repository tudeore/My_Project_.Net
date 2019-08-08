using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Host;
using System.Net.Http;
using System.Net;

namespace LearnAzureFunctions
{
    public static class ApplyForCC
    {
        [FunctionName("ApplyForCC")]
        public static async Task<HttpResponseMessage> Run(
        [HttpTrigger(AuthorizationLevel.Function,"post", Route = null)]HttpRequestMessage req,
                      TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            CCApplication ccApplication = await req.Content.ReadAsAsync<CCApplication>();
            log.Info($"Received Credit Card Application from : {ccApplication.Name }");
            return req.CreateResponse(HttpStatusCode.OK,
                            $"Application received and submitted for {ccApplication.Name}");
        }
    }
}