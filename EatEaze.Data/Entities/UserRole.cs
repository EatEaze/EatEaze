#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EatEaze.Data.Entities
{
    public class UserRole
    {
        [Key]
        public Guid RoleId { get; set; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string RoleName { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}