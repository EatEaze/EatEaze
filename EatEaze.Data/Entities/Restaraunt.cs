#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EatEaze.Data.Entities
{
    public class Restaraunt
    {
        [Key]
        public Guid RestarauntId { get; set; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false)]
        public string RestarauntName { get; set; }

        [JsonIgnore]
        public virtual ICollection<RestarauntInCity> RestarauntsInCities { get; set; }
        [JsonIgnore]
        public virtual ICollection<Position> Positions { get; set; }
    }
}
