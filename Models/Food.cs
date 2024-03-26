using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class Food
    {
        [Key]
        public int Fid { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public float price { get; set; }

        public string image { get; set; }
        [Required]
        public string veg { get; set; }
        public int foodCount { get; set; }
        public int Rid { get; set; }
        [ForeignKey("Rid")]
        public Restaurant restaurant { get; set; }
    }
}