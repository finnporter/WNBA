using Newtonsoft.Json;

namespace WNBA.Core.Api.DbHelper
{
    public class EntityBaseClass
    {
        [property: JsonProperty("id")] public Guid Id { get; set; }
    }
}
