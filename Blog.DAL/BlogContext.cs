using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.DAL.Data;

namespace Blog.DAL
{
    public class BlogContext : DbContext
    {
        public BlogContext(string connectionString)
        : base(connectionString) { }

        public BlogContext() : base("Blog") { }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }   
}
