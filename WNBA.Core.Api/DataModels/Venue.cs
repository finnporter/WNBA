using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.DbHelper;

namespace WNBA.Core.Api.DataModels
{
    /// <summary>
    /// Describes a venue with basic attributes
    /// </summary>
    public class Venue : EntityBaseClass
    {
        [property: JsonProperty("name")] public string Name { get; set; }
        [property: JsonProperty("city")] public string City { get; set; }
        [property: JsonProperty("state")] public string State { get; set; }
        [property: JsonProperty("capacity")] public double Capacity { get; set; }
    };
}
