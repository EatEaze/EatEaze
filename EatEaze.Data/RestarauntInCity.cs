using System.ComponentModel.DataAnnotations;

namespace EatEaze.Data
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
