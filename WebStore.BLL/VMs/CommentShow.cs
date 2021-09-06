using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.BLL.VMs
{
    public class CommentShow
    {
        public string ProductName { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
