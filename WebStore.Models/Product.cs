using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebStore.Models
{
    /*
        Product model
    */
    public class Product: BaseEntity
    {
        [Required]
        public string Category { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string File { get; set; }

        public virtual List<Review> Reviews { get; set; }
    }
}
