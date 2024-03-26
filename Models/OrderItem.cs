using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class OrderItem
    {
        [Key]
        public int itemId { get; set; }
        public int Oid { get; set; }
        public int Fid { get; set; }
        public int quantity { get; set; }
        [ForeignKey("Fid")]
        public Food food { get; set; }
        [ForeignKey("Oid")]
        public FoodOrder order { get; set; }
    }
}