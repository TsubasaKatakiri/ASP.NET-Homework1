using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebStore.Models
{
    /*
        Review for the product
    */
    public class Review : BaseEntity
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Score { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Text { get; set; }

        public string File { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual List<Comment> Comments { get; set; }

    }
}
