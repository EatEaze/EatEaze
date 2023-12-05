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

        public string? ImageURL { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

        [JsonIgnore]
        public virtual ICollection<RestarauntInCity> RestarauntsInCities { get; set; }
        [JsonIgnore]
        public virtual ICollection<Position> Positions { get; set; }
    }
}
