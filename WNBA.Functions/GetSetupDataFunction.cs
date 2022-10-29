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
    /// Seeds the database when first set up
    /// </summary>
    public class GetSetupDataFunction
    {
        private readonly ILogger<GetSetupDataFunction> logger;
        private readonly ISportsradarConnector sportsradarConnector;
        private readonly IDataHandlingService dataHandlingService;

        public GetSetupDataFunction(ILogger<GetSetupDataFunction> logger, ISportsradarConnector sportsradarConnector, IDataHandlingService dataHandlingService)
        {
            this.logger = logger;
            this.sportsradarConnector = sportsradarConnector;
            this.dataHandlingService = dataHandlingService;
        }

        [FunctionName(nameof(GetSetupDataFunction))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            logger.LogInformation("Beginning data seeding.");

            //Get Seasons from Api
            var seasons = await sportsradarConnector.ReadSeasonsEndpointAsync().ConfigureAwait(false);
            await dataHandlingService.HandleSeasonsAsync(seasons).ConfigureAwait(false);

            //Get LeagueHierarchy
            var hierarchy = await sportsradarConnector.ReadLeagueHierarchyAsync().ConfigureAwait(false);
            var teamIds = await dataHandlingService.HandleLeagueHierarchyAsync(hierarchy).ConfigureAwait(false);

            //Get TeamRosters
            foreach (var id in teamIds)
            {
                var teamroster = await sportsradarConnector.ReadTeamRosterEndpointAsync(id);
                await dataHandlingService.HandleTeamRosterAsync(id, teamroster).ConfigureAwait(false);
            }
            return new OkObjectResult("Setup finished");
        }
    }
}
