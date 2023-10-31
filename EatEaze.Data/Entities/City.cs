﻿#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace EatEaze.Data.Entities
{
    public class City
    {
        [Key]
        public Guid CityId { get; set; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false)]
        [MaxLength(200)]
        public string CityName { get; set; }

        public virtual ICollection<RestarauntInCity> RestarauntsInCities { get; set; }

    }
}