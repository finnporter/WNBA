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
    public class TeamPlayer
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public Guid TeamId { get; set; }
        public string? JerseyNumber { get; set; }
        public DateTime JoinedOn { get; set; }
        public DateTime? LeftOn { get; set; }

        public virtual Team Team { get; set; }
        public virtual Player Player { get; set; }
    }
}
