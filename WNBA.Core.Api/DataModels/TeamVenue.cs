using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.DbHelper;

namespace WNBA.Core.Api.DataModels
{
    /// <summary>
    /// Joins Teams and venues
    /// </summary>
    public class TeamVenue : EntityBaseClass
    { 
        public Guid VenueId { get; set; }
        public Guid TeamId { get; set; }

        public virtual Team Team { get; set; }
        public virtual Venue Venue { get; set; }
    }
}
