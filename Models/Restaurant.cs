using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class Restaurant
    {
        [Key]
        public int Rid { get; set; }
        [Required]
        public string RName { get; set; }
        public string RDescription { get; set; }
        public string logo { get; set; }

    }
}
