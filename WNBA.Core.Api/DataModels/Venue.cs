using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WNBA.Core.Api.DataModels
{
    /// <summary>
    /// Describes a venue with basic attributes
    /// </summary>
    public record Venue
    (
        [property: JsonProperty("id")] Guid Id,
        [property: JsonProperty("name")] string Name,
        [property: JsonProperty("city")] string City,
        [property: JsonProperty("state")] string State,
        [property: JsonProperty("capacity")] double Capacity
    );
}
