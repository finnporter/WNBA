using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.Connectors;
using WNBA.Core.Api.DataModels;
using WNBA.Core.Api.JsonModels;
using WNBA.Core.Api.Services;

namespace WNBA.Core.Api.Controllers.DataManagement;

[ApiController]
[ApiVersion("0.0")]
[Route("v{version:apiVersion}/basicdata")]
public class BasicDataController : BaseController
{
    private readonly ILogger<BasicDataController> logger;
    private readonly ISportsradarConnector sportsradarConnector;
    private readonly IDataHandlingService dataHandlingService;

    public BasicDataController(ILogger<BasicDataController> logger, ISportsradarConnector sportsradarConnector, IDataHandlingService dataHandlingService)
    {
        this.logger = logger;
        this.sportsradarConnector = sportsradarConnector;
        this.dataHandlingService = dataHandlingService;
    }

    [HttpGet]
    [Route("ping")]
    public OkObjectResult Ping()
    {
        logger.LogInformation("Basic data controller was pinged");
        return new OkObjectResult(200);
    }

    [HttpGet]
    [Route("teamroster/{id}")]
    public async Task<ObjectResult> ReadTeamRoster([FromRoute] string id)
    {
        logger.LogInformation($"Starting process to retrieve team roster for {id}.");

        //TODO move this to a connector
        var rawData = await sportsradarConnector.ReadTeamRosterEndpointAsync(id);
        var stream = new StreamReader(Request.Body);
        var body = await stream.ReadToEndAsync().ConfigureAwait(false);
        var teamroster = JsonConvert.DeserializeObject<TeamRoster>(body);
        var a = await dataHandlingService.HandleTeamRosterAsync(teamroster).ConfigureAwait(false);

        return new OkObjectResult(200);
    }
}