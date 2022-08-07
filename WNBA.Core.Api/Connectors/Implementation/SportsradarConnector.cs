using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Connectors.Implementation
{
    internal sealed class SportsradarConnector
    {
        private readonly EngineOptions options;

        public SportsradarConnector(IOptions<EngineOptions> options)
        {
            this.options = options.Value;
        }
        public async Task<TeamRoster> ReadTeamRosterEndpointAsync(string id)
        {
            var baseUrl = options.SportsradarBaseUrl;
            return await baseUrl
                .AppendPathSegment($"teams/{id}/profile.json")
                .SetQueryParam("api_key", options.SportsradarApiKey)
                .GetJsonAsync<TeamRoster>()
                .ConfigureAwait(false);
        }
    }
}
