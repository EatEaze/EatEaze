#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace EatEaze.Data
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserRoleId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
