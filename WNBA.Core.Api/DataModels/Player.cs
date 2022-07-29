using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WNBA.Core.Api.DataModels
{
    /// <summary>
    /// Describes a player with basic attributes
    /// </summary>
    public class Player
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string? College { get; set; }
        public string? Country { get; set; }
    }
}
