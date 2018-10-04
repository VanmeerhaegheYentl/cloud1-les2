
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Cloud1FunctionApp1
{
    public static class Function1
    {
        [FunctionName("HelloWorld")]
        public static async Task<IActionResult> HelloWorld([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "hello/{name}/{age}")]HttpRequest req, string name, int age, ILogger log)
        {
            //log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            //return name != null
            //    ? (ActionResult)new OkObjectResult($"Hello, {name}")
            //    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");

            string result = "hello " + name + "\nyou are " + age + " years old";
            return new OkObjectResult(result);
        }

        [FunctionName("sum")]
        public static async Task<IActionResult> sum([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "som/{nr1}/{nr2}")]HttpRequest req, int nr1, int nr2, ILogger log)
        {
            string result = nr1 + " + " + nr2 + " = " + (nr1 + nr2);
            return new OkObjectResult(result);
        }

        [FunctionName("fraction")]
        public static async Task<IActionResult> fraction([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "fraction/{nr1}/{nr2}")]HttpRequest req, decimal nr1, decimal nr2, ILogger log)
        {
            string result = "";

            try
            {
                if (nr1 == 0)
                {
                    return new BadRequestObjectResult("cannot divide by 0");
                }
                decimal devision = (nr1 / nr2);
                result = nr1 + " / " + nr2 + " = " + devision;
            }
            catch (System.Exception ex)
            {
                return new StatusCodeResult(500);
                throw;
            }

            return new OkObjectResult(result);
        }

    }
}
