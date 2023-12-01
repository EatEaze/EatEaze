#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EatEaze.Data.Entities
{
    public class Position
    {
        [Key]
        public Guid PositionId { get; set; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false)]
        public string PositionName { get; set; }

        public Guid? RestarauntId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required] 
        public double Price { get; set; }

        public string? ImageURL { get; set; }

        [JsonIgnore]
        public virtual Restaraunt Restaraunt { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual ICollection<PositionInOrder> PositionsInOrders { get; set; }
    }
}
