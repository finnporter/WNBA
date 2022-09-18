using WNBA.Core.Api.DbHelper;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.DataModels
{
    /// <summary>
    /// Describes a Team with basic attributes
    /// </summary>
    public class Team : EntityBaseClass
    { 
        public string Name { get; set; }
        public string Market { get; set; }
        public string Alias { get; set; }
        public DateTime? Founded { get; set; }  
        public string Conference { get; set; }
    
        public static Team ToModel(TeamDto data)
        {
            return new Team()
            {
                Id = data.Id,
                Name = data.Name,
                Market = data.Market,
                Alias = data.Alias,
                Founded = new DateTime(data.Founded, 1, 1),
                Conference = data.Conference.ToString()
            };
        }
    };
}
