#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EatEaze.Data.Entities
{
    public class City
    {
        [Key]
        public Guid CityId { get; set; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false)]
        [MaxLength(200)]
        public string CityName { get; set; }

        [JsonIgnore]
        public virtual ICollection<RestarauntInCity> RestarauntsInCities { get; set; }

    }
}
