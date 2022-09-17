using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
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

    /// <summary>
    /// Handles the reading of team roster data from an api and saving it in the db
    /// </summary>
    /// <param name="id"></param>
    [HttpGet]
    [Route("teamroster/{id}")]
    public async Task<ObjectResult> ReadTeamRoster([FromRoute] string id)
    {
        if (string.IsNullOrEmpty(id)) { throw new ArgumentNullException(nameof(id)); };
        logger.LogInformation("Starting process to retrieve team roster for {id}.", id);

        var teamroster = await sportsradarConnector.ReadTeamRosterEndpointAsync(id);

        //TEMP handing in an example payload until I'm sure the saving of it works
        //var stream = new StreamReader(Request.Body);
        //var body = await stream.ReadToEndAsync().ConfigureAwait(false);
        //var team = JsonConvert.DeserializeObject<TeamDto>(body);

        var result = await dataHandlingService.HandleTeamRosterAsync(id, teamroster).ConfigureAwait(false);

        return result ? new OkObjectResult(200) : new ObjectResult(HttpStatusCode.InternalServerError);
    }
}