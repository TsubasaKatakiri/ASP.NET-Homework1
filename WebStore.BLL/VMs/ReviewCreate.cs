using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.BLL.VMs
{
    public class ReviewCreate
    {
        public int Score { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public string File { get; set; }

        //public Guid ProductId { get; set; }
        //public string ProductCategory { get; set; }
        //public string ProductName { get; set; }
        //public string ProductDescription { get; set; }
        //public decimal ProductPrice { get; set; }
    }
}
