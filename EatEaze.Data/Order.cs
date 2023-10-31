using System.ComponentModel.DataAnnotations;

namespace EatEaze.Data
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

       
        public virtual User User { get; set; }
        public virtual ICollection<PositionInOrder> PositionsInOrders { get; set; }
    }
}
