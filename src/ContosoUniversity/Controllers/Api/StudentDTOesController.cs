using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using ContosoUniversity.ViewModels;

namespace ContosoUniversity.Controllers.Api
{
    public class StudentDTOesController : ApiController
    {
        public static StudentDTO studentDTO = new StudentDTO();
        public static Student student = new Student();
        private SchoolContext db = new SchoolContext();
        
        // GET: api/StudentDTOes/5
        [ResponseType(typeof(StudentDTO))]
        public IHttpActionResult GetStudentDTO(int id)
        {
            if(db.Students.Any(x => x.ID == id))
            {
                student = db.Students.Find(id);
            } else 
            {
                return NotFound();
            }
           // StudentDTO studentDTO = new StudentDTO();
            studentDTO.id = id;
            studentDTO.lastname = student.LastName;
            studentDTO.firstname = student.FirstMidName;
            studentDTO.enrollmentDate = student.EnrollmentDate.ToString("yyyy-MM-dd");
            studentDTO.enrollments = new List<Dictionary<string, int>>();
            foreach (Enrollment e in db.Enrollments.Where( x => x.StudentID==id) )
            {
                var dico = new Dictionary<string, int>();
                dico["courseId"] = e.CourseID;
                studentDTO.enrollments.Add(dico);
            }
            
            return Ok(studentDTO);
        }

        //// PUT: api/StudentDTOes/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutStudentDTO(int id, StudentDTO studentDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != studentDTO.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(studentDTO).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentDTOExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/StudentDTOes
        //[ResponseType(typeof(StudentDTO))]
        //public IHttpActionResult PostStudentDTO(StudentDTO studentDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.StudentDTOes.Add(studentDTO);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = studentDTO.id }, studentDTO);
        //}

        //// DELETE: api/StudentDTOes/5
        //[ResponseType(typeof(StudentDTO))]
        //public IHttpActionResult DeleteStudentDTO(int id)
        //{
        //    StudentDTO studentDTO = db.StudentDTOes.Find(id);
        //    if (studentDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    db.StudentDTOes.Remove(studentDTO);
        //    db.SaveChanges();

        //    return Ok(studentDTO);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentDTOExists(int id)
        {
            return db.StudentDTOes.Count(e => e.id == id) > 0;
        }
    }
}