using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.DataModels;

namespace WNBA.Core.Api.Controllers;

[ApiController]
[ApiVersion("0.0")]
[Route("v{version:apiVersion}")]
public class ArenaController : BaseController
{
    private readonly ApplicationDbContext context;
    private readonly ILogger<ArenaController> logger;

    public ArenaController(ApplicationDbContext context, ILogger<ArenaController> logger)
    {
        this.context = context;
        this.logger = logger;
    }

    [HttpGet]
    [Route("ping")]
    public OkObjectResult Ping()
    {
        logger.LogInformation("Arena controller was pinged");
        return new OkObjectResult(200);
    }

    [HttpGet]
    [Route("arenas")]
    public async Task<ObjectResult> GetAll()
    {
        logger.LogInformation("Getting all arenas");

        try
        {
            var arenas = await context.Arenas.ToListAsync();
            var json = JsonConvert.SerializeObject(arenas);

            return new OkObjectResult(json);
        }
        catch (Exception e)
        {
            return GetErrorResult(e.Message);
        }
    }

    [HttpPost]
    [Route("arena")]
    public async Task<ObjectResult> Create()
    {
        logger.LogInformation("Request to create arena received.");

        var stream = new StreamReader(Request.Body);
        var body = await stream.ReadToEndAsync().ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(body) || string.IsNullOrWhiteSpace(body.TrimStart('{').TrimEnd('}')))
        {
            return new ObjectResult("No valid data for validation.")
            {
                StatusCode = 422
            };
        }

        try
        {
            var arena = JsonConvert.DeserializeObject<Arena>(body);
            await context.AddAsync<Arena>(arena);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return GetErrorResult(e.Message);
        }

        return new OkObjectResult("Successfully created arena.");
    }
}