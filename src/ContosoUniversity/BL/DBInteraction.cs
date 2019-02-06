using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.BL
{
    public static class DBInteraction
    {
        private static SchoolContext db = new SchoolContext();

        public static bool PersonExists(string login)
        {
            return db.People.Any(x => x.Login == login);
        }

        public static void AddInstructor(string LastName, string FirstMidName, DateTime HireDate, string Login = "", string Password = "")
        {
            //if it's not already in the DB, then we can add it
            if (!PersonExists(Login))
            {
                Instructor instructor = new Instructor();
                instructor.LastName = LastName;
                instructor.FirstMidName = FirstMidName;
                instructor.Login = Login;
                instructor.Password = Password;
                instructor.HireDate = HireDate;
                db.People.Add(instructor);
                db.SaveChanges();
            }
        }

        public static void AddStudent(string LastName, string FirstMidName, DateTime EnrollmentDate, string Login = "", string Password = "")
        {
            //if it's not already in the DB, then we can add it
            if (!PersonExists(Login))
            {
                Student student = new Student();
                student.LastName = LastName;
                student.FirstMidName = FirstMidName;
                student.Login = Login;
                student.Password = Password;
                student.EnrollmentDate = EnrollmentDate;
                db.People.Add(student);
                db.SaveChanges();
            }
        }

        public static void AddPerson(string Discriminator, string LastName, string FirstMidName, DateTime StartingDate, string Login="", string Password="")
        {
            switch (Discriminator)
            {
                case "Instructor":
                    AddInstructor(LastName, FirstMidName, StartingDate, Login, Password);
                    break;
                case "Student":
                    AddStudent(LastName, FirstMidName, StartingDate, Login, Password);
                    break;
                default:
                    break;
            }
        }

        public static void RemovePerson(int PersonID)
        {
            if(db.People.Any(person => person.ID == PersonID))
            {
                db.People.Remove(db.People.Find(PersonID));
                db.SaveChanges();
            }
        }

    }
    
}