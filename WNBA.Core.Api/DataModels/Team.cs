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
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public Conference Conference { get; set; }
        public DateTime FoundedOn { get; set; }
    }
}
