
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

using Cloud1_FunctionApp1.Model;

namespace Cloud1_FunctionApp1
{
    public static class Function3
    {
        [FunctionName("Sum")]
        public static async Task<IActionResult> Sum([HttpTrigger(AuthorizationLevel.Function, "post", Route = "Sum")]HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            SomModel data = JsonConvert.DeserializeObject<SomModel>(requestBody);

            int som = data.nr1 + data.nr2;
            SomResultaat result = new SomResultaat();
            result.resurltaat = som;
            return new OkObjectResult(result);
        }
    }
}
