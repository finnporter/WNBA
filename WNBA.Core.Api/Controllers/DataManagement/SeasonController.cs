using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.Connectors;
using WNBA.Core.Api.DataModels;
using WNBA.Core.Api.JsonModels;
using WNBA.Core.Api.Services;

namespace WNBA.Core.Api.Controllers.DataManagement;

/// <summary>
/// CRUD functionality for seasons
/// </summary>
[ApiController]
[ApiVersion("0.0")]
[Route("v{version:apiVersion}")]
public class SeasonController : BaseController
{
    private readonly ApplicationDbContext context;
    private readonly ILogger<SeasonController> logger;
    private readonly ISportsradarConnector sportsradarConnector;
    private readonly IDataHandlingService dataHandlingService;

    public SeasonController(ApplicationDbContext context, ILogger<SeasonController> logger, ISportsradarConnector sportsradarConnector, IDataHandlingService dataHandlingService)
    {
        this.context = context;
        this.logger = logger;
        this.sportsradarConnector = sportsradarConnector;
        this.dataHandlingService = dataHandlingService;
    }

    //Index
    [HttpGet]
    [Route("seasons")]
    public async Task<ObjectResult> GetAll()
    {
        logger.LogInformation("Getting all seasons");

        try
        {
            var seasons = await context.Seasons.ToListAsync().ConfigureAwait(false);
            var json = JsonConvert.SerializeObject(seasons);

            return new OkObjectResult(json);
        }
        catch (Exception e)
        {
            return GetObjectResult(520, e.Message);
        }
    }

    //Read
    [HttpGet]
    [Route("season/{id}")]
    public async Task<ObjectResult> GetById([FromRoute] string id)
    {
        logger.LogInformation("Getting season with id: {id}", id);

        try
        {
            var season = await context.Seasons.FirstAsync(x => x.Id.ToString() == id).ConfigureAwait(false);
            var json = JsonConvert.SerializeObject(season);

            return new OkObjectResult(json);
        }
        catch (Exception e)
        {
            return GetObjectResult(520, e.Message);
        }
    }

    //Create or update from Api
    [HttpGet]
    [Route("seasons/api")]
    public async Task<ObjectResult> GetAllFromApi()
    {
        logger.LogInformation("Getting all seasons from API");

        try
        {
            var seasons = await sportsradarConnector.ReadSeasonsEndpointAsync().ConfigureAwait(false);
            await dataHandlingService.HandleSeasonsAsync(seasons).ConfigureAwait(false);

            return new OkObjectResult(200);
        }
        catch (Exception e)
        {
            return GetObjectResult(520, e.Message);
        }
    }

}