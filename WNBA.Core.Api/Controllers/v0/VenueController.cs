using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.DataModels;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Controllers;

/// <summary>
/// CRUD functionality for venues
/// </summary>
[ApiController]
[ApiVersion("0.0")]
[Route("v{version:apiVersion}")]
public class VenueController : BaseController
{
    private readonly ApplicationDbContext context;
    private readonly ILogger<VenueController> logger;

    public VenueController(ApplicationDbContext context, ILogger<VenueController> logger)
    {
        this.context = context;
        this.logger = logger;
    }

    //Index
    [HttpGet]
    [Route("venues")]
    public async Task<ObjectResult> GetAll()
    {
        logger.LogInformation("Getting all venues");

        try
        {
            var venues = await context.Venues.ToListAsync().ConfigureAwait(false);
            var json = JsonConvert.SerializeObject(venues);

            return new OkObjectResult(json);
        }
        catch (Exception e)
        {
            return GetObjectResult(520, e.Message);
        }
    }

    //Read
    [HttpGet]
    [Route("venue/{id}")]
    public async Task<ObjectResult> GetVenueById([FromRoute] string id)
    {
        logger.LogInformation("Getting venue with id: {id}", id);

        try
        {
            var venue = await context.Venues.FirstAsync(x => x.Id.ToString() == id).ConfigureAwait(false);
            var json = JsonConvert.SerializeObject(venue);

            return new OkObjectResult(json);
        }
        catch (Exception e)
        {
            return GetObjectResult(520, e.Message);
        }
    }

    //Create
    [HttpPost]
    [Route("venue")]
    public async Task<ObjectResult> CreateVenue()
    {
        logger.LogInformation("Request to create venue received.");

        var stream = new StreamReader(Request.Body);
        var body = await stream.ReadToEndAsync().ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(body) || string.IsNullOrWhiteSpace(body.TrimStart('{').TrimEnd('}')))
        {
            return GetObjectResult(422, "No valid data.");
        }

        try
        {
            var venue = JsonConvert.DeserializeObject<Venue>(body);
            await context.AddAsync<Venue>(venue).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
        catch (Exception e)
        {
            return GetObjectResult(520, e.Message);
        }

        return new OkObjectResult("Successfully created venue.");
    }

    //Update
    [HttpPatch]
    [Route("venue/{id}")]
    public async Task<ObjectResult> UpdateVenue([FromRoute] string id)
    {
        logger.LogInformation("Request to update venue with id: {id}", id);

        var stream = new StreamReader(Request.Body);
        var body = await stream.ReadToEndAsync().ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(body) || string.IsNullOrWhiteSpace(body.TrimStart('{').TrimEnd('}')))
        {
            return GetObjectResult(422, "No valid data.");
        }

        try
        {
            var venue = JsonConvert.DeserializeObject<Venue>(body);
            if (id == venue.Id.ToString())
            {
                context.Update<Venue>(venue);
                await context.SaveChangesAsync().ConfigureAwait(false);

                return new OkObjectResult("Successfully updated venue.");
            }            
        }
        catch (Exception e)
        {
            return GetObjectResult(520, e.Message);
        }

        return GetObjectResult(500, "Something went wrong. I don't know how we ended up here.");
    }

    //Update Multiple
    [HttpPatch]
    [Route("venues")]
    public async Task<ObjectResult> UpdateMultipleVenues()
    {
        logger.LogInformation($"Request to update multiple venues");

        var stream = new StreamReader(Request.Body);
        var body = await stream.ReadToEndAsync().ConfigureAwait(false);

        if (string.IsNullOrWhiteSpace(body) || string.IsNullOrWhiteSpace(body.TrimStart('{').TrimEnd('}')))
        {
            return GetObjectResult(422, "No valid data.");
        }

        try
        {
            var venueCollection = JsonConvert.DeserializeObject<VenueCollection>(body);
            foreach (var venue in venueCollection.Venues)
            {
                context.Update<Venue>(venue);
                await context.SaveChangesAsync().ConfigureAwait(false);               
            }
            return new OkObjectResult($"Successfully updated venues");
        }
        catch (Exception e)
        {
            return GetObjectResult(520, e.Message);
        }

        return GetObjectResult(500, "Something went wrong. I don't know how we ended up here.");
    }

    //Delete
    [HttpDelete]
    [Route("venue/{id}")]
    public async Task<ObjectResult> DeleteVenue([FromRoute] string id)
    {
        logger.LogInformation("Request to delete venue with id: {id}", id);

        try
        {
            var venue = await context.Venues.FirstOrDefaultAsync(x => x.Id.ToString() == id).ConfigureAwait(false);
            if (venue == null) { return GetObjectResult(422, "Can't delete venue that doesn't exist. Please check id."); }
            context.Venues.Remove(venue);
            await context.SaveChangesAsync().ConfigureAwait(false);

            return new OkObjectResult("Successfully deleted venue.");
        }
        catch (Exception e)
        {
            return GetObjectResult(520, e.Message);
        }
    }
}