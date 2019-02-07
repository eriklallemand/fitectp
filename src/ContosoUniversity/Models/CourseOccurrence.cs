using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class CourseOccurrence
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseOccurrenceID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public int DayOfWeek { get; set; }
        [Required]
        public int StartingHour { get; set; }
        [Required]
        public int StartingMinute { get; set; }
        [Required]
        public int DurationMinutes { get; set; }
        
        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}