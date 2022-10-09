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
    public class TeamPlayerSeason : EntityBaseClass
    { 
        public Guid TeamId { get; set; }
        public Guid PlayerId { get; set; }
        public Guid SeasonId { get; set; }
        
        public virtual Player Player { get; set; }
        public virtual Season Season { get; set; }
        public virtual Team Team { get; set; }
    };
}
