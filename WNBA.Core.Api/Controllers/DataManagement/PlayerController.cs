using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Controllers.DataManagement
{
    /// <summary>
    /// Handles api calls regarding players
    /// </summary>
    [ApiController]
    [ApiVersion("0.0")]
    [Route("v{version:apiVersion}")]
    public class PlayerController : BaseController
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<PlayerController> logger;

        public PlayerController(ApplicationDbContext context, ILogger<PlayerController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpGet]
        [Route("player/{id}")]
        public async Task<ObjectResult> ReadPlayer([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id)) { throw new ArgumentNullException(nameof(id)); };
            logger.LogInformation("Starting process to retrieve player {id}.", id);

            //TODO connect to sportsradar

            //TEMP handing in an example player until this works
            var stream = new StreamReader(Request.Body);
            var body = await stream.ReadToEndAsync();
            var player = JsonConvert.DeserializeObject<PlayerDto>(body);
        }
    }
}
