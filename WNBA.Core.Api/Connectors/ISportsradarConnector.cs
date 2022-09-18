using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Connectors
{
    /// <summary>
    /// Handles the connection to the Sportsradar API
    /// </summary>
    public interface ISportsradarConnector
    {
        /// <summary>
        /// Reads the team roster endpoint, given a team id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TeamDto> ReadTeamRosterEndpointAsync(string id);

        /// <summary>
        /// Reads the seasons endpoint
        /// </summary>
        /// <returns>A list of all seasons</returns>
        Task<List<SeasonDto>> ReadSeasonsEndpointAsync();
    }
}
