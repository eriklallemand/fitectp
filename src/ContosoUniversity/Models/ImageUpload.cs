using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Models
{
    public class ImageUpload
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image
            {
                get { return Name.Replace(" ", string.Empty) + ".jpg"; }
            }
    }
}