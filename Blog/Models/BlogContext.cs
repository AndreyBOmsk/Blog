using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Blog.Models

{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("DBConnection")
        { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BadWord> BadWords { get; set; }
    }
}