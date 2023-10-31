#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EatEaze.Data.Entities
{
    [PrimaryKey(nameof(CityId), nameof(RestarauntId))]
    public class RestarauntInCity
    {
        public Guid CityId { get; set; }

        public Guid RestarauntId { get; set; }

        public virtual City City { get; set; }
        public virtual Restaraunt Restaraunt { get; set; }
    }
}
