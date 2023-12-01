#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace EatEaze.Responce
{
        public class FoodCardResponce
        {
            public Guid PositionId { get; set; }

            public string PositionName { get; set; }

            public string RestarauntName { get; set; }

            public string? RestarauntImageURL { get; set; }

            public string CategoryName { get; set; }

            public int Count { get; set; }

            public double Price { get; set; }

            public string? ImageURL { get; set; }
        }
}
