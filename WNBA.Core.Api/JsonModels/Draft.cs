using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.DataModels;

namespace WNBA.Core.Api.JsonModels;

public record Draft(
    [property: JsonProperty("team_id")] Guid TeamId,
    [property: JsonProperty("year")] float Year,
    [property: JsonProperty("round")] string Round,
    [property: JsonProperty("pick")] string Pick);
