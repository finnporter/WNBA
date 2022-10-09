using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WNBA.Core.Api.JsonModels
{
    /// <summary>
    /// Describes a player with basic attributes
    /// </summary>
    public record PlayerDto
    (
        [property: JsonProperty("id")] Guid Id,
        [property: JsonProperty("status")] string Status,
        [property: JsonProperty("first_name")] string FirstName,
        [property: JsonProperty("last_name")] string LastName,
        [property: JsonProperty("height")] double HeightInINches,
        [property: JsonProperty("weight")] double WeightInPounds,
        [property: JsonProperty("position")] string Position,
        [property: JsonProperty("jersey_number")] string JerseyNumber,
        [property: JsonProperty("experience")] string Experience,
        [property: JsonProperty("college")] string College,
        [property: JsonProperty("high_school")] string HighSchool,
        [property: JsonProperty("birth_place")] string BirthPlace,
        [property: JsonProperty("birthdate")] string BirthDate,
        [property: JsonProperty("updated")] DateTime UpdatedOn,
        [property: JsonProperty("rookie_year")] float RookieYear,
        [property: JsonProperty("draft")] Draft Draft
    )
    {
        [property: JsonProperty("seasons")]
        public List<PlayerSeasonDto>? Seasons { get; set; }

        [property: JsonProperty("team")]
        public TeamIdDto? CurrentTeamId { get; set; }

        public virtual double HeightInCm
        {
            get
            {
                return HeightInINches * 2.54;
            }
        }
        public virtual double WeightInKg
        {
            get
            {
                return WeightInPounds * 0.4535924;
            }
        }
    }
}
