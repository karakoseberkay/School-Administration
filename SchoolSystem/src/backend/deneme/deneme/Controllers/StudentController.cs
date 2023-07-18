using deneme.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using deneme.Dtos.Student;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace deneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly EF_DataContext _db;
        public StudentController(EF_DataContext dataContext)
        {
            _db = dataContext;
        }

        static List<Student> students = new List<Student>();
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            var books = _db.Students.ToList();

            return books;



        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _db.Students.FirstOrDefault(s => s.Id == id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public string Post([FromBody] AddStudentDto student)
        {
            if (!ModelState.IsValid)
                return "Başarısız";


            var studentToSave = new Student();

            studentToSave.Name = student.Name;
            studentToSave.DepartmentId = student.DepartmentId;
            studentToSave.CreatedDate = student.CreatedDate;

            _db.Students.Add(studentToSave);
            _db.SaveChanges();

            return "Ekleme başarılı";
        }


        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public string PutAsync(int id, [FromBody] UpdateStudentDto student)
        {

            var studentFromDB = _db.Students.FirstOrDefault(s => s.Id == id);

            if (studentFromDB == null) return "Öğrenci Bulunamadı";

            studentFromDB.Name = student.Name;
            studentFromDB.DepartmentId = student.DepartmentId;

            _db.Students.Update(studentFromDB);
            _db.SaveChanges();

            return "Güncelleme başarılı";
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _db.Students.Remove(student);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    

        }
    }

