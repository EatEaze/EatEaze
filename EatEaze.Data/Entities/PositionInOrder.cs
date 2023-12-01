#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EatEaze.Data.Entities
{
    [PrimaryKey(nameof(OrderId), nameof(PositionId))]
    public class PositionInOrder
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();

        public Guid PositionId { get; set; }

        [Required]
        public int Count { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public virtual Position Position { get; set; }
    }
}
