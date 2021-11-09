using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProducts.Models
{
    public class Product
    {
        [Key()]
        public int Id { get; set; }
        public string Category { get; set; }

        [DisplayName("Name")]
        public string ProductName { get; set; }
        public string Description { get; set; }

        [DisplayName("Available Date")]
        public DateTime AvailableDate { get; set; }
    }
}