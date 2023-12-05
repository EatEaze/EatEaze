#pragma warning disable CS8618

using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EatEaze.Data.Entities
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false)]
        public string CategoryName { get; set; }


        [JsonIgnore]
        public virtual ICollection<Restaraunt> Restaraunts { get; set; }

        [JsonIgnore]
        public virtual ICollection<Position> Positions { get; set; }
    }
}
