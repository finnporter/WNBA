using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.DataModels;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Controllers.DataManagement;

[ApiController]
[ApiVersion("0.0")]
[Route("v{version:apiVersion}/basicdata")]
public class BasicDataController : BaseController
{
    private readonly ApplicationDbContext context;
    private readonly ILogger<BasicDataController> logger;
    private readonly EngineOptions options;

    public BasicDataController(ApplicationDbContext context, ILogger<BasicDataController> logger, IOptions<EngineOptions> options)
    {
        this.context = context;
        this.logger = logger;
        this.options = options.Value;
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

        var baseUrl = options.SportsradarBaseUrl;
        var rawData = await baseUrl
            .AppendPathSegment($"teams/{id}/profile.json")
            .SetQueryParam("api_key", options.SportsradarApiKey)
            .GetJsonAsync<TeamRoster>()
            .ConfigureAwait(false);

        return new OkObjectResult(rawData);
    }
}