﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Data;
using System.Data.Entity;

namespace Blog.DAL.Repository
{
    public class RepositoryReview : IRepository<Review>
    {
        private BlogContext db;
        public RepositoryReview()
        {
            db = new BlogContext();
        }
        public RepositoryReview(BlogContext context)
        {
            this.db = context;
        }
        public IEnumerable<Review> GetAll()
        {
            return db.Reviews;
        }
        public Review Get(int id)
        {
            return db.Reviews.Find(id);
        }
        public void Create(Review review)
        {
            db.Reviews.Add(review);
        }

        public void Update(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Review review = db.Reviews.Find(id);
            if (review != null)
            {
                db.Reviews.Remove(review);
            }
        }
        public int GetCount()
        {
            return db.Reviews.Count();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
