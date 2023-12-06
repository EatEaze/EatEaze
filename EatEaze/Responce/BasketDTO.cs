#pragma warning disable CS8618

using EatEaze.Data.Entities;
using Newtonsoft.Json;

namespace EatEaze.Responce
{
    public class BasketDTO
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public ICollection<PositionInOrder> PositionsInOrders { get; set; }
    }
}
