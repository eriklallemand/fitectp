using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.DAL;
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
        public ActionResult StudentSignup()
        {
            return View();
        }

        // POST: Authentication/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentSignup([Bind(Include = "ID,LastName,FirstMidName,Login,Password,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }
        
         // GET: Authentication/Create
        public ActionResult StudentSignin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentSignin([Bind(Include = "Login,Password")] Student student)
        {
            if(db.Students.Any(x => x.Login == student.Login && x.Password == student.Password))
            {
                Session["User"] = student.Login;
                Session["UserFirstName"] = student.FirstMidName;
                Session["UserLastName"] = student.LastName;


            } else
            {
                ViewBag["Erreur"] = "Login or password invalid !";
            }

            //if (ModelState.IsValid)
            //{
            //    db.People.Add(student);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return View();
        }



        // GET: Authentication/Create
        public ActionResult InstructorSignup()
        {
            return View();
        }

        // POST: Authentication/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InstructorSignup([Bind(Include = "LastName,FirstMidName,Login,Password")] UserLoginInfo userLoginInfo)
        {
            if (ModelState.IsValid)
            {

                Instructor instructor = new Instructor();
                instructor.LastName = userLoginInfo.LastName;
                instructor.FirstMidName = userLoginInfo.FirstMidName;
                instructor.Login = userLoginInfo.Login;
                instructor.Password = userLoginInfo.Password;
                instructor.HireDate = DateTime.Now;

                db.People.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Authentication/Create
        public ActionResult InstructorSignin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InstructorSignin([Bind(Include = "Login,Password")] Instructor instructor)
        {
            if (db.Students.Any(x => x.Login == instructor.Login && x.Password == instructor.Password))
            {
                int y = 0;
                y++;

                /////////////////////////////////////////////////
                //insert code to make authentication persistent
                /////////////////////////////////////////////////

                //HttpContext.Profile.UserName = student.Login;
                //HttpContext.Profile.IsAnonymous = false;
            }


            if (ModelState.IsValid)
            {
                db.People.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instructor);
        }


    }
}
