using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WNBA.Core.Api.DataModels
{
    /// <summary>
    /// Joins Teams and venues
    /// </summary>
    public record TeamVenue
    (
        Guid Id,
        Guid VenueId,
        Guid TeamId)
    {
        public virtual Team Team { get; set; }
        public virtual Venue Venue { get; set; }
    }
}
