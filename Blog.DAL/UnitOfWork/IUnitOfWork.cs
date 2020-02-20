using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Data;
using System.Data.Entity;
using Blog.DAL.Repository;

namespace Blog.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Article> Articles { get; }
        IRepository<Review> Reviews { get; }
        IRepository<Vote> Votes { get; }
        IRepository<Tag> Tags { get; }
        void Save();
    }
}
