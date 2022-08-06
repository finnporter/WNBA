using Newtonsoft.Json;
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
        public string? Status { get; set; }
        public string? FirstName { get; set; }
        public  string? LastName { get; set; }
        public double? HeightInINches { get; set; }
        public double? HeightInCm { get; set; }
        public double? WeightInPounds { get; set; }
        public double? WeightInKg { get; set; }
        public string? Position { get; set; }
        public string? JerseyNumber { get; set; }
        public string? Experience { get; set; }
        public string? College { get; set; }
        public string? HighSchool { get; set; }
        public string? BirthPlace { get; set; }
        public string? BirthDate { get; set; }
        public DateTime UpdatedOn { get; set; }
        public float? RookieYear { get; set; }
        public Guid? DraftedBy { get; set; }
        public float? DraftedYear { get; set; }
        public string? Round { get; set; }
        public string? Pick { get; set; }
 
    }
}
