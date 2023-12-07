using System.ComponentModel.DataAnnotations;

namespace EatEaze.AdminWebApplication.Models
{
    public class CategoriesViewModel
    {
        [Key]
        public Guid CategoryId { get; set; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false)]
        public string CategoryName { get; set; }
    }
}
