using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Data
{
    public class Article
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Text { get; set; }
        public DateTime Publish { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public Article()
        {
            Tags = new List<Tag>();
        }
    }
}
