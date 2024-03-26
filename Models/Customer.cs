using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class Customer
    {
        [Key]
        public int Cid { get; set; }
        [Required]
        public string CName { get; set; }
        public long phone { get; set; }
    }
}