using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers
{
    public class ImageUploadController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: ImageUpload
        public ActionResult UploadPhoto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadPhoto(HttpPostedFileBase photo)
        {

            if (photo != null && photo.ContentLength > 0)
            {
                string directory = Server.MapPath(@"~\Images\");

                if (photo.ContentLength > 102400)
                {
                    ModelState.AddModelError("photo", "The size of the file should not exceed 100 KB");
                    TempData["ErrorMessage"] = "The size of the file should not exceed 100 KB";
                    return View();
                }

                var supportedTypes = new[] { "jpg", "jpeg", "png" };

                var fileExt = Path.GetExtension(photo.FileName).Substring(1);

                if (!supportedTypes.Contains(fileExt))
                {
                    ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
                    TempData["ErrorMessage"] = "Invalid type. Only the following types (jpg, jpeg, png) are supported.";
                    return View();
                }

                //var fileName = Path.GetFileName(photo.FileName);

                string UserId = Session["UserId"].ToString();
                int UserIdAsInt = int.Parse(UserId);
                var fileName = Path.GetFileName(UserId + "." + fileExt);
                photo.SaveAs(Path.Combine(directory, fileName));
                ViewBag.photopath = Path.Combine("..", "Images", fileName);

                Person p = db.People.First(x => x.ID == UserIdAsInt );
                p.ImagePath = fileName;
                db.SaveChanges();
            }
            return View();
        }

        // GET: DeletePhoto
        public ActionResult DeletePhoto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePhoto(string photoFileName)
        {
            //string UserId = Session["UserId"].ToString();
            //int UserIdAsInt = int.Parse(UserId);
            Person p = db.People.Find(Session["UserId"]);
            p.ImagePath = null;
            db.SaveChanges();

            //Session["DeleteSuccess"] = "No";
            var photoName = "";
            photoName = photoFileName;
            string fullPath = Request.MapPath(photoName);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                //Session["DeleteSuccess"] = "Yes";
            }
            return RedirectToAction("UploadPhoto");
        }
        //GET: Student/my_profile
        public ActionResult My_Profile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(db.Students.Any(x => x.ID== id))
            {
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Courses = db.Courses;
                return View("My_Profile_Student",student);
            }
            else
            {
                Instructor instructor= db.Instructors.Find(id);
                if (instructor == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Courses = db.Courses;
                ViewBag.OfficeAssignments = db.OfficeAssignments;
                return View("My_Profile_Instructor",instructor);
            }

        }

    }
}
 