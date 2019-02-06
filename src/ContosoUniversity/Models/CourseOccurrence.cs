using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class CourseOccurrence
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int CourseID { get; set; }
        public string Day { get; set; }
        [Range(0, 23)]
        public int Hour { get; set; }
        [Range(0, 59)]
        public int Minute { get; set; }
        public int Duration { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}