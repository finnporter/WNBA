using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WNBA.Core.Api.Connectors;
using WNBA.Core.Api.Services;

namespace WNBA.Functions
{
    /// <summary>
    /// Gets seasons from the Api to update the database
    /// </summary>
    public class SeasonsFunction
    {
        private readonly ILogger<SeasonsFunction> logger;
        private readonly ISportsradarConnector sportsradarConnector;
        private readonly IDataHandlingService dataHandlingService;

        public SeasonsFunction(ILogger<SeasonsFunction> logger, ISportsradarConnector sportsradarConnector, IDataHandlingService dataHandlingService)
        {
            this.logger = logger;
            this.sportsradarConnector = sportsradarConnector;
            this.dataHandlingService = dataHandlingService;
        }

        [FunctionName(nameof(SeasonsFunction))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
        {
            logger.LogDebug("Getting seasons from API");

            //Get Seasons from Api
            var seasons = await sportsradarConnector.ReadSeasonsEndpointAsync().ConfigureAwait(false);
            await dataHandlingService.HandleSeasonsAsync(seasons).ConfigureAwait(false);

            logger.LogDebug("Seasons successfully imported.");

            return new OkObjectResult(seasons);
        }
    }
}
