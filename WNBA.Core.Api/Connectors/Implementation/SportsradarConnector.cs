using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Connectors.Implementation
{
    internal sealed class SportsradarConnector : ISportsradarConnector
    {
        private readonly EngineOptions options;
        private string baseUrl;

        public SportsradarConnector(IOptions<EngineOptions> options)
        {
            this.options = options.Value;
            baseUrl = this.options.SportsradarBaseUrl;
        }

        ///</inheridoc>
        public async Task<TeamDto> ReadTeamRosterEndpointAsync(string id)
        {
            var baseUrl = options.SportsradarBaseUrl;

            if (string.IsNullOrEmpty(id)) { throw new ArgumentNullException(nameof(id)); };
            if (string.IsNullOrEmpty(baseUrl)) { throw new ArgumentNullException(nameof(baseUrl)); };

            return await baseUrl
                .AppendPathSegment($"teams/{id}/profile.json")
                .SetQueryParam("api_key", options.SportsradarApiKey)
                .GetJsonAsync<TeamDto>()
                .ConfigureAwait(false);
        }

        public async Task<List<SeasonDto>> ReadSeasonsEndpointAsync()
        {
            var baseUrl = options.SportsradarBaseUrl;

            if (string.IsNullOrEmpty(baseUrl)) { throw new ArgumentNullException(nameof(baseUrl)); };

            var seasonList = await baseUrl
                .AppendPathSegment("league/seasons.json")
                .SetQueryParam("api_key", options.SportsradarApiKey)
                .GetJsonAsync<SeasonListDto>()
                .ConfigureAwait(false);

            return seasonList.Seasons;
        }

        public async Task<LeagueHierarchyDto> ReadLeagueHierarchyAsync()
        {
            var baseUrl = options.SportsradarBaseUrl;

            return await baseUrl
                .AppendPathSegment("league/hierarchy.json")
                .SetQueryParams("api_key", options.SportsradarApiKey)
                .GetJsonAsync<LeagueHierarchyDto>()
                .ConfigureAwait(false);
        }

        public async Task<PlayerDto> ReadPlayerEndpointAsync(string playerId)
        {
            var baseUrl = options.SportsradarBaseUrl;

            return await baseUrl
                .AppendPathSegment(string.Format("player/{playerId}/profile.json", playerId))
                .SetQueryParams("api_key", options.SportsradarApiKey)
                .GetJsonAsync<PlayerDto>()
                .ConfigureAwait(false);
        }
    }
}
