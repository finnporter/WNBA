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

    public ObjectResult GetErrorResult(string message)
    {
        return new ObjectResult(message)
        {
            StatusCode = 500
        };
    }
}