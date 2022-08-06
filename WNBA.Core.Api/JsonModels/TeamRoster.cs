using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.DataModels;

namespace WNBA.Core.Api.JsonModels;

public record TeamRoster(
    [property: JsonProperty("id")] Guid Id,
    [property: JsonProperty("name")] string Name,
    [property: JsonProperty("market")] string Market,
    [property: JsonProperty("alias")] string Alias,
    [property: JsonProperty("founded")] string Founded,
    [property: JsonProperty("venues")] Venue Venue,
    [property: JsonProperty("conference")] Conference Conference,
    [property: JsonProperty("coaches")] IEnumerable<Coach> Coaches,
    [property: JsonProperty("players")] IEnumerable<Player> Players);
