using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.ViewModels
{
    public class AnonymousHomepageCourses

    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? NumberOfSessions { get; set; }

    }
}