using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.DataModels;

namespace WNBA.Core.Api.JsonModels;

public record SeasonDto(
    [property: JsonProperty("id")] Guid Id,
    [property: JsonProperty("year")] int Year,
    [property: JsonProperty("start_date")] DateTime StartDate,
    [property: JsonProperty("end_date")] DateTime EndDate,
    [property: JsonProperty("status")] string Status,
    [property: JsonProperty("type")] SeasonTypeDto SeasonType
    );
