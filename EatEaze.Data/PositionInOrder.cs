using System.ComponentModel.DataAnnotations;

namespace EatEaze.Data
{
    public class PositionInOrder
    {
        [Key]
        public Guid OrderId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid PositionId { get; set; }

        [Required]
        public int Count { get; set; }


        public virtual Order Order { get; set; }
        public virtual Position Position { get; set; }
    }
}
