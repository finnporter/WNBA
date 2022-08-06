using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WNBA.Core.Api.DataModels
{
    /// <summary>
    /// Describes a player with basic attributes
    /// </summary>
    public record Player
    (
        Guid Id,
        string FirstName,
        string LastName,
        DateTime DateOfBirth,
        double Height,
        double Weight,
        string? College,
        string? Country
    );
}
