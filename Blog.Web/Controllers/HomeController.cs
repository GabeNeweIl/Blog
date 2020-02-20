using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.DAL.Data;
using Blog.DAL.UnitOfWork;
using Blog.Web.Models;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork db;
        public HomeController()
        {
            db = new UnitOfWork();
        }
        public ActionResult Index(int page = 1)
        {
            int pageSize = 3;
            IEnumerable<Article> articlesPerPage = db.Articles.GetAll().Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = db.Articles.GetCount() };
            PageViewMdodel pageViewMdodel = new PageViewMdodel { PageInfo = pageInfo, Articles = articlesPerPage };
            ViewBag.VotesBag = db.Votes.GetAll();
            ViewBag.ArticlesBag = db.Articles.GetAll();
            return View(pageViewMdodel);
        }
        [HttpGet]
        public ActionResult NewArticle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewArticle(string heading, string text,string tag)
        {
            db.Articles.Create(new Article { Heading = heading, Text = text, Publish = DateTime.Now });
            db.Save();
            string[] tags = tag.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> listVote = new List<string>();
            for (int j = 1; j < db.Tags.GetCount(); j++)
            {
                listVote.Add(db.Tags.Get(j).Name);
            }
            for (int i = 0; i < tags.Length; i++)
            {
                if (!listVote.Contains(tags[i]))
                db.Tags.Create(new Tag { Name = tags[i], Articles = new List<Article> { db.Articles.Get(db.Articles.GetCount())} });
                else
                {
                    //если такой тег существет, то добавить свзь с статьей РЕАЛИЗОВАТЬ!!!
                }
            }
            db.Save();
            Index();
            return View("Index");
        }
        public ViewResult ShowMore(int? id) //Показать всю статью
        {
            if (id != null)
            {
                int newId = (int)id;
                return View(db.Articles.Get(newId));
            }
            else
                return View("Error404");
        }
        public ViewResult ShowArticleByTag(int? id) //Показать статьи по тегу
        {
            if (id != null)
            {
                int newId = (int)id;
                return View(db.Tags.Get(newId));
            }
            else
                return View("Error404");
        }
        [HttpGet]
        public ActionResult Voting()
        {
            //Index();
            return View("Index");
        }
        [HttpPost]
        public ActionResult Voting(string vote)
        {
            if (vote != null)
            {
                if (vote == "Male")
                {
                    db.Votes.Get(1).Count++;
                    db.Save();
                }
                else
                {
                    db.Votes.Get(2).Count++;
                    db.Save();
                }
            }
            Index();
            return View("ThanksForVote");
        }
    }
}