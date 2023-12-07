using System.ComponentModel.DataAnnotations;

namespace EatEaze.AdminWebApplication.Models
{
    public class PositionsViewModel
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
    }
}
