using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.DataModels;
using WNBA.Core.Api.DbHelper;

namespace WNBA.Core.Api.DataModels;

public class Coach : EntityBaseClass
{
    [property: JsonProperty("first_name")] public string FirstName { get; set; }
    [property: JsonProperty("last_name")] public string LastName { get; set; }
    [property: JsonProperty("position")] public string Position { get; set; }
    [property: JsonProperty("experience")] public int? Experience { get; set; }
}
