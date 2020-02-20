using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Data;
using System.Data.Entity;


namespace Blog.DAL.Repository
{
    public class RepositoryVote : IRepository<Vote>
    {
        private BlogContext db;
        public RepositoryVote()
        {
            db = new BlogContext();
        }
        public RepositoryVote(BlogContext context)
        {
            this.db = context;
        }
        public IEnumerable<Vote> GetAll()
        {
            return db.Votes;
        }
        public Vote Get(int id)
        {
            return db.Votes.Find(id);
        }
        public void Create(Vote vote)
        {
            db.Votes.Add(vote);
        }

        public void Update(Vote vote)
        {
            db.Entry(vote).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Vote vote = db.Votes.Find(id);
            if (vote != null)
            {
                db.Votes.Remove(vote);
            }
        }
        public int GetCount()
        {
            return db.Votes.Count();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}

