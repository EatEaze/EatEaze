#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace EatEaze.Data
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

        public string? ImageURL { get; set; }


        public virtual Restaraunt Restaraunt { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<PositionInOrder> PositionsInOrders { get; set; }
    }
}
