﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.DataModels;

namespace WNBA.Core.Api.JsonModels;

public record SeasonTypeDto(
    [property: JsonProperty("code")] string Code,
    [property: JsonProperty("name")] string Name);