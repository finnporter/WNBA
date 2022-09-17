using Newtonsoft.Json;

namespace WNBA.Core.Api.DbHelper
{
    /// <summary>
    /// Parent class for database models, so they can be saved in a generic function.
    /// </summary>
    public class EntityBaseClass
    {
        [property: JsonProperty("id")] public Guid Id { get; set; }
    }
}
