using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.DbHelper;

namespace WNBA.Core.Api.DataModels
{
    /// <summary>
    /// Joins Teams and Players
    /// </summary>
    public class TeamPlayer : EntityBaseClass
    { 
        public Guid PlayerId { get; set; }
        public Guid TeamId { get; set; }
        public DateTime? EndedOn { get; set; }

        public virtual Team Team { get; set; }
        public virtual Player Player { get; set; }        
    };
}
