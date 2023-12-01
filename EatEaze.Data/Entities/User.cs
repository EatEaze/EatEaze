#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EatEaze.Data.Entities
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

        public string Token { get; set; }

        [JsonIgnore]
        public virtual UserRole UserRole { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
