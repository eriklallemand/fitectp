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



        //// GET: Authentication/Create
        //public ActionResult StudentSignup()
        //{
        //    return View();
        //}

        //// POST: Authentication/Create
        //// Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        //// plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult StudentSignup([Bind(Include = "ID,LastName,FirstMidName,Login,Password,EnrollmentDate")] Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.People.Add(student);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(student);
        //}
        
        // // GET: Authentication/Create
        //public ActionResult StudentSignin()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult StudentSignin([Bind(Include = "Login,Password")] Student student)
        //{
        //    if(db.Students.Any(x => x.Login == student.Login && x.Password == student.Password))
        //    {
        //        Session["User"] = student.Login;
        //        Session["UserFirstName"] = student.FirstMidName;
        //        Session["UserLastName"] = student.LastName;


        //    } else
        //    {
        //        ViewBag["Erreur"] = "Login or password invalid !";
        //    }

        //    return View();
        //}



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
            if(!db.People.Any(x => x.Login == userLoginInfo.Login))
            { 
                DBInteraction.AddPerson(userLoginInfo.Discriminator, userLoginInfo.LastName, userLoginInfo.FirstMidName, DateTime.Now, userLoginInfo.Login, userLoginInfo.Password);
                return RedirectToAction("Index");
            } else
            {
            return View();
            }
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
                Session["UserFirstName"] = person.FirstMidName;
                Session["UserLastName"] = person.LastName;
                return RedirectToAction("Index");
            } else
            {
                ViewBag["Erreur"] = "Login or password invalid !";
                return View();
            }
        }


    }
}
