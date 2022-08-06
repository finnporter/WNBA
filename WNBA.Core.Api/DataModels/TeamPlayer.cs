using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WNBA.Core.Api.DataModels
{
    /// <summary>
    /// Joins Teams and Players
    /// </summary>
    public record TeamPlayer
    (
        Guid Id,
        Guid PlayerId,
        Guid TeamId,
        string? JerseyNumber,
        DateTime JoinedOn,
        DateTime? LeftOn
    )
    {
        public virtual Team Team { get; set; }
        public virtual Player Player { get; set; }
    };
}
