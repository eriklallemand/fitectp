using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class CourseOccurrence
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
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
        
        public virtual Course Course { get; set; }

    }
}