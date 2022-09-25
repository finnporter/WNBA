using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.Connectors;
using WNBA.Core.Api.JsonModels;
using WNBA.Core.Api.Services;

namespace WNBA.Core.Api.Controllers.DataManagement
{
    /// <summary>
    /// Handles api calls regarding players
    /// </summary>
    [ApiController]
    [ApiVersion("0.0")]
    [Route("v{version:apiVersion}")]
    public class PlayerController : BaseController
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<PlayerController> logger;
        private readonly ISportsradarConnector sportsradarConnector;
        private readonly IDataHandlingService dataHandlingService;

        public PlayerController(ApplicationDbContext context, ILogger<PlayerController> logger, ISportsradarConnector sportsradarConnector, IDataHandlingService dataHandlingService)
        {
            this.context = context;
            this.logger = logger;
            this.sportsradarConnector = sportsradarConnector;
            this.dataHandlingService = dataHandlingService;
        }

        [HttpGet]
        [Route("player/{id}")]
        public async Task<ObjectResult> ReadPlayerFromApi([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id)) { throw new ArgumentNullException(nameof(id)); };
            logger.LogInformation("Starting process to retrieve player {id}.", id);

            try
            {
                //TODO connect to sportsradar
                //var player = await sportsradarConnector.ReadPlayerEndpointAsync(id).ConfigureAwait(false);

                //TEMP handing in an example player until this works
                var stream = new StreamReader(Request.Body);
                var body = await stream.ReadToEndAsync();
                var player = JsonConvert.DeserializeObject<PlayerDto>(body);

                await dataHandlingService.HandlePlayerAsync(id, player);

                return new ObjectResult("The player was successfully added.");

            }
            catch (Exception ex)
            {
                return new ObjectResult($"Player couldn't be added added because: {ex.Message}");

            }


        }
    }
}
