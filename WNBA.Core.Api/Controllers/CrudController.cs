using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WNBA.Core.Api.Configuration;

namespace WNBA.Core.Api.Controllers;

[ApiController]
[ApiVersion("0.0")]
[Route("v{version:apiVersion}/rawdata")]
public class CrudController : Controller
{
    private readonly ApplicationDbContext context;
    private readonly ILogger<CrudController> logger;

    public CrudController(ApplicationDbContext context, ILogger<CrudController> logger) 
    { 
        this.context = context; 
        this.logger = logger;
    }

    [HttpGet]
    [Route("ping")]
    public OkObjectResult Ping()
    {
        logger.LogInformation("Crud controller was pinged");
        return new OkObjectResult(200);
    }
}