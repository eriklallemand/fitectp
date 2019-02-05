using System;
using System.Collections.Generic;
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
        [HttpPost]
        public ActionResult UploadPhoto(string Image,
       HttpPostedFileBase photo)
        {
            string path = Image;

            if (photo != null)
                photo.SaveAs(path);

           // return RedirectToAction("Index");
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
 