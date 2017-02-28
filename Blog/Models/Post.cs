using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Post
    {
        public long Id { get; set; }
        public string PostText { get; set; }
        public DateTime DateCreated { get; set; }
        public string ImageUrl { get; set; }
        public Priority Priority { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }

    public enum Priority
    {
        Low,
        Midle,
        Hight
    }

}