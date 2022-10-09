using Newtonsoft.Json;

namespace WNBA.Core.Api.JsonModels;

public record PlayerSeasonDto(
    [property: JsonProperty("id")] Guid Id,
    [property: JsonProperty("year")] int Year,
    [property: JsonProperty("type")] string Type,
    [property: JsonProperty("teams")] List<PlayerSeasonStatsTeamDto> PlayerStats);
