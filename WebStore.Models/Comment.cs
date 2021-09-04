using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebStore.Models
{
    /*
        Comment for the review
    */
    public class Comment : BaseEntity
    {
        public Guid ReviewId { get; set; }
        public virtual Review Review { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
