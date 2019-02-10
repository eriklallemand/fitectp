using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.DAL;
using ContosoUniversity.BL;
using ContosoUniversity.Models;
using ContosoUniversity.ViewModels;

namespace ContosoUniversity.Controllers
{
    public class AuthenticationController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Authentication
        public ActionResult Index()
        {
            //return View(db.Students.ToList());
            return View();
        }
        

        // GET: Authentication/Create
        public ActionResult Signup()
        {
            return View();
        }

        // POST: Authentication/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup([Bind(Include = "LastName,FirstMidName,Login,Password,Discriminator")] UserLoginInfo userLoginInfo)
        {
            //if signup info is correct
            if (ModelState.IsValid)
            {
                //if login is not already taken
                if (!db.People.Any(x => x.Login == userLoginInfo.Login))
                {
                    DBInteraction.AddPerson(userLoginInfo.Discriminator, userLoginInfo.LastName, userLoginInfo.FirstMidName, DateTime.Now, userLoginInfo.Login, userLoginInfo.Password);
                    return RedirectToAction("Index");
                } else
                {
                    ViewData["Erreur"] = "This login already exists.";
                    return View();
                }
            }
            return View();
    }

        // GET: Authentication/Create
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signin([Bind(Include = "Login,Password")] UserLoginInfo userLoginInfo)
        {
            if (db.People.Any(x => x.Login == userLoginInfo.Login && x.Password == userLoginInfo.Password))
            {
                Person person = db.People.First(x => x.Login == userLoginInfo.Login && x.Password == userLoginInfo.Password);
                Session["User"] = person.Login;
                Session["UserLogin"] = person.Login;
                Session["UserId"] = person.ID;
                Session["UserFirstName"] = person.FirstMidName;
                Session["UserLastName"] = person.LastName;
                Session["UserDiscriminator"] = db.Students.Any(x => x.ID == person.ID) ? "Student" : "Instructor" ;
                return RedirectToAction("../Home/Index");
            } else
            {
                ViewData["Erreur"] = "Invalid login or password";
                return View();
            }
        }


    }
}
