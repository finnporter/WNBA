using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WNBA.Core.Api.DataModels
{
    /// <summary>
    /// Describes an Arena with basic attributes
    /// </summary>
    public class Arena
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Capacity { get; set; }
    }
}
