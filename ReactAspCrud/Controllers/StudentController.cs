using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReactAspCrud.Models;
using VisioForge.GStreamer.API;

namespace ReactAspCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {


            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetStudent")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentDbContext.Students.ToListAsync();
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<Student> AddStudent(Student objStudent)

        {
            _studentDbContext.Students.Add(objStudent);
            await _studentDbContext.SaveChangesAsync();
            return objStudent;
        }

        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        public async Task<Student> UpdateStudent(int id, Student objStudent)

        {
            var existingStudent = await _studentDbContext.Students.FindAsync(id);
            if (existingStudent != null)
            {
                // Update specific properties of the existingStudent object
                existingStudent.stname = objStudent.stname;
                existingStudent.course = objStudent.course;

                await _studentDbContext.SaveChangesAsync();
                return existingStudent;
            }
            else
            {
                // Handle the case when the student with the given id is not found
                // You can return an appropriate response or throw an exception
                // for example: throw new ArgumentException("Student not found");
                return null;
            }
        }


        [HttpDelete]
        [Route("DeleteStudent/{id}")]


        public bool DeleteStudent(int id)

        {
            bool a = false;
            var student =_studentDbContext.Students.Find(id);
            if (student!= null) 
            {
                a = true;
                _studentDbContext.Entry(student).State = EntityState.Deleted;
                _studentDbContext.SaveChangesAsync();

            }
            else
            {

                a = false;
            }
           return a;
        } 



    }
}
