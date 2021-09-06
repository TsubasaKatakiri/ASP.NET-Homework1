using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.BLL.VMs
{
    public class ReviewShow
    {
        public string ProductName { get; set; }
        public int Score { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public string File { get; set; }
        public DateTime DateCreated { get; set; }
        public List<CommentShow> Comments { get; set; } = new List<CommentShow>();
    }
}
