using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_Demo.Models
{
    public class Product
    {
        [Key]
        public long ProductID { get; set; }
        [Required(ErrorMessage ="Please Enter the product name")]
        public string ProductName { get; set; }

        [Required]
        [Range(0,1000, ErrorMessage ="The price value is btwn 0-1000")]
        public Nullable<decimal> Price { get; set; }

        [Required]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }

        [Required]
        public string AvailabilityStatus { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }
        
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}