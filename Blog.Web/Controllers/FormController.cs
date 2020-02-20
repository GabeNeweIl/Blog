using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Form(string name, int? age, string sex, bool cat, bool dog, bool another, bool none)
        {
            string Pet = "Your pet: ";
            age = age ?? 0;
            if (sex == "male") sex = "Male";
            else sex = "Female";
            if (cat == true) Pet += "cat";
            if (dog == true) Pet += " dog";
            if (another == true) Pet = "You have some another pet";
            if (none == true) Pet = "You do not have any pet(";
            ViewBag.FormBag = $"Name: {name} Age: {age} Sex: {sex} {Pet} ";
            return View("FormResult");
        }
    }
}