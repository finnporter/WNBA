using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.DataModels;

namespace WNBA.Core.Api.Controllers;

public class BaseController : Controller
{
    public BaseController()
    {
    }

    /// <summary>
    /// For checking if the engine is available.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("ping")]
    public OkObjectResult Ping()
    {
        return new OkObjectResult("WNBA engine pinged.")
        {
            StatusCode = 200,
        };
    }

    public ObjectResult GetObjectResult(int code, string message)
    {
        return new ObjectResult(message)
        {
            StatusCode = code
        };
    }
}