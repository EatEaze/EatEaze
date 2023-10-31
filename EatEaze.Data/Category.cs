#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace EatEaze.Data
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false)]
        public string CategoryName { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
