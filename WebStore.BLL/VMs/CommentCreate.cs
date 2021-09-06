using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.BLL.VMs
{
    public class CommentCreate
    {
        public string Username { get; set; }
        public string Text { get; set; }
        public Guid ReviewId { get; set; }
    }
}
