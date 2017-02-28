using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }

        public long PostId { get; set; }
        public Post Post { get; set; }
    }
}