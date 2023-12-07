using System.ComponentModel.DataAnnotations;

namespace EatEaze.AdminWebApplication.Models
{
    public class RestarauntsViewModel
    {
        [Key]
        public Guid RestarauntId { get; set; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false)]
        public string RestarauntName { get; set; }

        public string? ImageURL { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}
