using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.BLL.VMs
{
    public class ProductCreate
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
