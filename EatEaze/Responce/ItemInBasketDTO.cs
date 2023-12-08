using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatEaze.Responce
{
    public class ItemInBasketDTO
    {
        public FoodCardResponce Item { get; set; }
        public int Count { get; set; }
    }
}
