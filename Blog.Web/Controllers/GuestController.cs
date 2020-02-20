using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.DAL.Data;
using Blog.DAL.UnitOfWork;

namespace Blog.Web.Controllers
{
    public class GuestController : Controller
    {
        UnitOfWork db;
        public GuestController()
        {
            db = new UnitOfWork();
        }

        public ActionResult ReviewView()
        {
            return View(db.Reviews.GetAll());
        }
        [HttpPost]
        public ActionResult ReviewView(string name, string text)
        {
            db.Reviews.Create(new Review { Name = name, Text = text, Publish = DateTime.Now });
            db.Save();
            ReviewView();
            return View();
        }
    }
}