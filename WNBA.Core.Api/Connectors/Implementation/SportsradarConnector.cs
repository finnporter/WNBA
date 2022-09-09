﻿using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Connectors.Implementation
{
    internal sealed class SportsradarConnector : ISportsradarConnector
    {
        private readonly EngineOptions options;

        public SportsradarConnector(IOptions<EngineOptions> options)
        {
            this.options = options.Value;
        }
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
    }
}