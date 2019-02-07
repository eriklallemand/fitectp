﻿using ContosoUniversity.DAL;
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
                    return View();
                }

                var supportedTypes = new[] { "jpg", "jpeg", "png" };

                var fileExt = Path.GetExtension(photo.FileName).Substring(1);

                if (!supportedTypes.Contains(fileExt))
                {
                    ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePhoto(string photoFileName)
        {
            //Session["DeleteSuccess"] = "No";
            var photoName = "";
            photoName = photoFileName;
            string fullPath = Request.MapPath(photoName);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                //Session["DeleteSuccess"] = "Yes";
            }
            return RedirectToAction("Index");
        }
        public string Find_Image(string id)
        {
            string partialName = id;
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(@"~\Images\");
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialName + "*.*");
            string fullName="";
            foreach (FileInfo foundFile in filesInDir)
            {
                 fullName = foundFile.FullName;
            }
            return fullName;
        }


        //GET: Student/my_profile
        public ActionResult My_Profile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Courses = db.Courses;
            return View(student);
        }
        //public string Find_Image(string id)
        //{
        //    Student student = db.Students.Find(id);
        //    string partialName = id;
        //    DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(@"~\Images\");
        //    FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialName + "*.*");
        //    string fullName = "";
        //    foreach (FileInfo foundFile in filesInDir)
        //    {
        //        fullName = foundFile.FullName;
        //    }
        //    return fullName;
        //}
    }
}
 