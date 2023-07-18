using deneme.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using deneme.Dtos.Teacher;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace deneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly EF_DataContext _db;
        public TeacherController(EF_DataContext dataContext)
        {
            _db = dataContext;
        }

        static List<Teacher> teacher = new List<Teacher>();
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Teacher> GetTeachers()
        {
            var books = _db.Teachers.ToList();

            return books;



        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Teacher Get(int id)
        {
            return _db.Teachers.FirstOrDefault(s => s.Id == id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public string Post([FromBody] AddTeacherDto teacher)
        {

            if (!ModelState.IsValid)
                return "Başarısız";

            var TeacherToSave = new Teacher();

            TeacherToSave.Name = teacher.Name;
            TeacherToSave.DepartmentId = teacher.DepartmentId;

            _db.Teachers.Add(TeacherToSave);
            _db.SaveChanges();

            return "Ekleme başarılı";
        }


        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public string PutAsync(int id, [FromBody] UpdateTeacherDto teacher)
        {

            var teacherFromDB = _db.Teachers.FirstOrDefault(s => s.Id == id);

            if (teacherFromDB == null) return "Öğretmen Bulunamadı";

            // var studentToUpdate = new Student();


            teacherFromDB.Name = teacher.Name;
            teacherFromDB.DepartmentId = teacher.DepartmentId;



            _db.Teachers.Update(teacherFromDB);
            _db.SaveChanges();

            return "Güncelleme başarılı";


        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            /*
            students.RemoveAll(s => s.Id == id);
            */
            var user = await _db.Teachers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _db.Teachers.Remove(user);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
