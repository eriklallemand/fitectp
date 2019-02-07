using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers
{
    public class ImageUploadController : Controller
    {
        // GET: ImageUpload
        public ActionResult UploadPhoto()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult UploadPhoto(HttpPostedFileBase photo)
        //{
        //    string directory = Server.MapPath(@"~\Images\");

        //    if (photo != null && photo.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(photo.FileName);
        //        photo.SaveAs(Path.Combine(directory, fileName));
        //    }

        //    //return RedirectToAction("Index");
        //    return View();
        //}

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
                var fileName = Path.GetFileName(Session["UserId"].ToString() + "." + fileExt);
                photo.SaveAs(Path.Combine(directory, fileName));
                ViewBag.photopath = Path.Combine("..", "Images", fileName);
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
    }
}
 