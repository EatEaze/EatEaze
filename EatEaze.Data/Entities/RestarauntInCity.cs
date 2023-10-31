#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace EatEaze.Data.Entities
{
    public class RestarauntInCity
    {
        [Key]
        public Guid CityId { get; set; }

        [Key]
        public Guid RestarauntId { get; set; }

        public virtual City City { get; set; }
        public virtual Restaraunt Restaraunt { get; set; }
    }
}
