using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Services;

public interface IDataHandlingService
{
    /// <summary>
    /// Handles the saving of a teamroster to the database
    /// </summary>
    /// <param name="id"></param>
    /// <param name="team"></param>
    Task<bool> HandleTeamRosterAsync(string id, TeamDto team);

    /// <summary>
    /// Handles the saving of multiple seasons to the database.
    /// </summary>
    /// <param name="seasons"></param>
    /// <returns></returns>
    Task HandleSeasonsAsync(List<SeasonDto> seasons);
}
