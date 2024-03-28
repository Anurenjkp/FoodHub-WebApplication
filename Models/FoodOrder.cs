using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class FoodOrder
    {
        [Key]
        public int Oid { get; set; }
        [Required]
        public int Cid { get; set; }

        public int Rid { get; set; }
        public DateTime date { get; set; }
        public float totalPrice { get; set; }
        public string orderType { get; set; }
        public string paymentStatus { get; set; }
        public string orderStatus { get; set; }
        public int Token { get; set; }
        [ForeignKey("Cid")]
        public Customer customer { get; set; }


    }
}