using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class FoodViewModel
    {
        public int Rid { get; set; }
        public float totalPrice { get; set; }
        public string orderType { get; set; }
        public int[] quantity { get; set; }
        public int[] FoodList { get; set; }
        public int Token { get; set; }
    }

    public class ItemViewModel
    {
        public string FoodName { get; set; }
        public int Quantity { get; set; }

        public int Price { get; set; }
    }
}