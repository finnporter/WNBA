using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.DataModels;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Controllers.CRUD;

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

    //Index
    [HttpGet]
    [Route("arenas")]
    public async Task<ObjectResult> GetAll()
    {
        logger.LogInformation("Getting all arenas");

        try
        {
            var arenas = await context.Arenas.ToListAsync().ConfigureAwait(false);
            var json = JsonConvert.SerializeObject(arenas);

            return new OkObjectResult(json);
        }
        catch (Exception e)
        {
            return GetErrorResult(e.Message);
        }
    }

    //Read
    [HttpGet]
    [Route("arena/{id}")]
    public async Task<ObjectResult> GetArenaById([FromRoute] string id)
    {
        logger.LogInformation($"Getting arena with id: {id}");

        try
        {
            var arena = await context.Arenas.FirstAsync(x => x.Id.ToString() == id).ConfigureAwait(false);
            var json = JsonConvert.SerializeObject(arena);

            return new OkObjectResult(json);
        }
        catch (Exception e)
        {
            return GetErrorResult(e.Message);
        }
    }

    //Create
    [HttpPost]
    [Route("arena")]
    public async Task<ObjectResult> CreateArena()
    {
        logger.LogInformation("Request to create arena received.");

        var stream = new StreamReader(Request.Body);
        var body = await stream.ReadToEndAsync().ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(body) || string.IsNullOrWhiteSpace(body.TrimStart('{').TrimEnd('}')))
        {
            return new ObjectResult("No valid data.")
            {
                StatusCode = 422
            };
        }

        try
        {
            var arena = JsonConvert.DeserializeObject<Arena>(body);
            await context.AddAsync<Arena>(arena).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
        catch (Exception e)
        {
            return GetErrorResult(e.Message);
        }

        return new OkObjectResult("Successfully created arena.");
    }

    //Update
    [HttpPatch]
    [Route("arena/{id}")]
    public async Task<ObjectResult> UpdateArena([FromRoute] string id)
    {
        logger.LogInformation($"Request to update arena with id: {id}");

        var stream = new StreamReader(Request.Body);
        var body = await stream.ReadToEndAsync().ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(body) || string.IsNullOrWhiteSpace(body.TrimStart('{').TrimEnd('}')))
        {
            return new ObjectResult("No valid data.")
            {
                StatusCode = 422
            };
        }

        try
        {
            var arena = JsonConvert.DeserializeObject<Arena>(body);
            if (id == arena.Id.ToString())
            {
                context.Update<Arena>(arena);
                await context.SaveChangesAsync().ConfigureAwait(false);

                return new OkObjectResult("Successfully updated arena.");
            }            
        }
        catch (Exception e)
        {
            return GetErrorResult(e.Message);
        }

        return GetErrorResult("Something went wrong. I don't know how we ended up here.");
    }

    //Update Multiple
    [HttpPatch]
    [Route("arenas")]
    public async Task<ObjectResult> UpdateMultipleArenas()
    {
        logger.LogInformation($"Request to update multiple arenas");

        var stream = new StreamReader(Request.Body);
        var body = await stream.ReadToEndAsync().ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(body) || string.IsNullOrWhiteSpace(body.TrimStart('{').TrimEnd('}')))
        {
            return new ObjectResult("No valid data.")
            {
                StatusCode = 422
            };
        }

        try
        {
            var arenaCollection = JsonConvert.DeserializeObject<ArenaCollection>(body);
            foreach (var arena in arenaCollection.Arenas)
            {
                context.Update<Arena>(arena);
                await context.SaveChangesAsync().ConfigureAwait(false);               
            }
            return new OkObjectResult($"Successfully updated arenas");
        }
        catch (Exception e)
        {
            return GetErrorResult(e.Message);
        }

        return GetErrorResult("Something went wrong. I don't know how we ended up here.");
    }

    //Delete
    [HttpDelete]
    [Route("arena/{id}")]
    public async Task<ObjectResult> DeleteArena([FromRoute] string id)
    {
        logger.LogInformation($"Request to delete arena with id: {id}");

        try
        {
            var arena = await context.Arenas.FirstOrDefaultAsync(x => x.Id.ToString() == id).ConfigureAwait(false);
            if (arena == null) { return GetErrorResult("Can't delete area that doesn't exist. Please check id."); }
            context.Arenas.Remove(arena);
            await context.SaveChangesAsync().ConfigureAwait(false);

            return new OkObjectResult("Successfully deleted arena.");
        }
        catch (Exception e)
        {
            return GetErrorResult(e.Message);
        }
    }
}