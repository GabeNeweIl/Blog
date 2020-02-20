using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Data;
using System.Data.Entity;

namespace Blog.DAL.Repository
{
    public class RepositoryTag : IRepository<Tag>
    {
        private BlogContext db;
        public RepositoryTag()
        {
            db = new BlogContext();
        }
        public RepositoryTag(BlogContext context)
        {
            this.db = context;
        }
        public IEnumerable<Tag> GetAll()
        {
            return db.Tags;
        }
        public Tag Get(int id)
        {
            return db.Tags.Find(id);
        }
        public void Create(Tag tag)
        {
            db.Tags.Add(tag);
        }

        public void Update(Tag tag)
        {
            db.Entry(tag).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag != null)
            {
                db.Tags.Remove(tag);
            }
        }
        public int GetCount()
        {
            return db.Tags.Count();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
