using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    /*
        Product model
    */
    public class Product: BaseEntity
    {
        public string Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public virtual List<Review> Reviews { get; set; } = new List<Review>();
    }
}
