#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EatEaze.Data.Entities
{
    [PrimaryKey(nameof(CityId), nameof(RestarauntId))]
    public class RestarauntInCity
    {
        public Guid CityId { get; set; }

        public Guid RestarauntId { get; set; }

        [JsonIgnore]
        public virtual City City { get; set; }
        [JsonIgnore]
        public virtual Restaraunt Restaraunt { get; set; }
    }
}
