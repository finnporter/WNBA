using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.DataModels;

namespace WNBA.Core.Api.JsonModels;

public record Coach(
    [property: JsonProperty("id")] Guid Id,
    [property: JsonProperty("first_name")] string FirstName,
    [property: JsonProperty("last_name")] string LastName,
    [property: JsonProperty("position")] string Position,
    [property: JsonProperty("experience")] int Experience);
