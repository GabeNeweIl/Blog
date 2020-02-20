using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Data;
using Blog.DAL;
using System.Data.Entity;

namespace Blog.DAL.Repository
{
    public class RepositoryArticle : IRepository<Article>
    {
        private BlogContext db;
        public RepositoryArticle()
        {
            db = new BlogContext();
        }
        public RepositoryArticle(BlogContext context)
        {
            this.db = context;
        }
        public IEnumerable<Article> GetAll()
        {
            return db.Articles;
        }
        public Article Get(int id)
        {
            return db.Articles.Find(id);
        }
        public void Create(Article article)
        {
            db.Articles.Add(article);
        }

        public void Update(Article article)
        {
            db.Entry(article).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Article article = db.Articles.Find(id);
            if (article != null)
            {
                db.Articles.Remove(article);
            }
        }
        public int GetCount()
        {
            return db.Articles.Count();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
