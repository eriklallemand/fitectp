using System.Collections.Generic;

namespace ContosoUniversity.ViewModels
{
    public class CourseWithOccurrences
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Credits { get; set; }
        public string DepartmentID { get; set; }
        public CourseOccurrence Occurrence { get; set; }

    }
}