using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.Enums;

namespace WNBA.Core.Api.DataModels
{
    /// <summary>
    /// Describes a Team with basic attributes
    /// </summary>
    public record Team
    (
        Guid Id,
        string Name,
        string State,
        string City,
        Conference Conference,
        DateTime FoundedOn
    );
}
