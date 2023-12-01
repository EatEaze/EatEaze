#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EatEaze.Data.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<PositionInOrder> PositionsInOrders { get; set; }
    }
}
