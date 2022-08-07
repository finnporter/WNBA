using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Services
{
    public interface IDataHandlingService
    {
        Task<bool> HandleTeamRosterAsync(TeamRoster teamRosterData);
    }
}
