using Newtonsoft.Json;

namespace WNBA.Core.Api.JsonModels;

public record PlayerSeasonStatsTeamDto(
    [property: JsonProperty("id")] Guid Id,
    [property: JsonProperty("name")] string Name,
    [property: JsonProperty("alias")] string Alias,
    [property: JsonProperty("total")] PlayerSeasonStatsDto PlayerSeasonStatsTeam,
    [property: JsonProperty("average")] PlayerSeasonStatsDto PlayerAverageStats);
