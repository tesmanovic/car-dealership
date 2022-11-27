using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmyzeTask.Model;
using YamlDotNet.Serialization.NamingConventions;
using System.Web.Http;
using SmyzeTask.Repository;

namespace SmyzeTask.src
{
    public static class Function
    {

        [FunctionName("GetCarSpecification")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "cars")][FromQuery] CarDto dto, ILogger log)
        {
            log.LogInformation("Function GetCarSpecification processing a request...");

            if (!dto.IsValid())
                return new BadRequestErrorMessageResult("Some of the mandatory query parameters are misisng.");

            try
            {
                var car = await CarRepository.GetCar(dto.Brand, dto.Model, dto.Offer);

                log.LogInformation($"------- Output result: -------" + Environment.NewLine + car.ToFlatJson());
                return new OkObjectResult(car.ToFlatJson());
            }
            catch (Exception ex)
            {
                log.LogError("Error happend during GetCarSpecification function execution. Exeption:  " + ex.Message);
                return new NotFoundResult();
            }

        }
    }
}
