using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.DbHelper;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.DataModels
{
    /// <summary>
    /// Describes a venue with basic attributes
    /// </summary>
    public class Season : EntityBaseClass
    {
        [property: JsonProperty("id")] public string Id { get; set; }
        [property: JsonProperty("year")] public int Year { get; set; }
        [property: JsonProperty("start_date")] public DateTime StartDate { get; set; }
        [property: JsonProperty("end_date")] public DateTime EndDate { get; set; }
        [property: JsonProperty("status")] public string Status { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }

        public static Season ToModel(SeasonDto seasonDto)
        {
            return new Season()
            {
                Id = seasonDto.Id,
                Year = seasonDto.Year,
                StartDate = seasonDto.StartDate,
                EndDate = seasonDto.EndDate,
                Status = seasonDto.Status,
                TypeCode = seasonDto.SeasonType.Code,
                TypeName = seasonDto.SeasonType.Name
            };
        }
    };
}
