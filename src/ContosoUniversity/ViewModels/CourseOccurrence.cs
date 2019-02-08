using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.ViewModels
{
    public class CourseOccurrence
    {
        public int CourseID { get; set; }
        [Required]
        [Range(0, 7)]
        public int DayOfWeek { get; set; }
        [Required]
        [Range(8, 18)]
        public int StartingHour { get; set; }
        [Required]
        [Range(0, 59)]
        public int StartingMinute { get; set; }
        [Required]
        [Range(1,660)]
        public int DurationMinutes { get; set; }

        public DateTime StartDate { get; set; }
    }
}