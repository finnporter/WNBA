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
    public class TeamVenue
    {
        public Guid Id { get; set; }
        public Guid VenueId { get; set; }
        public Guid TeamId { get; set; }
        public DateTime UsedSince { get; set; }
        public DateTime? UsedUntil { get; set; }

        public virtual Team Team { get; set; }
        public virtual Venue Venue { get; set; }
    }
}
