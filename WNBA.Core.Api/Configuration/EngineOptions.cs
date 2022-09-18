using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WNBA.Core.Api.Configuration
{
    /// <summary>
    /// Information important for running this data engine
    /// </summary>
    public class EngineOptions
    {
        public const string Configuration = "Configuration";
        public string SportsradarApiKey { get; set; } = string.Empty;
        public string SportsradarBaseUrl { get; set; } = string.Empty;
    }
}
