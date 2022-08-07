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
    public record TeamCoach
    (
        Guid Id,
        Guid TeamId,
        Guid CoachId
    )
    {
        public virtual Team Team { get; set; }
        public virtual Coach Coach { get; set; }
    };
}
