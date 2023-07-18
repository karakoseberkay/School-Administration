using deneme.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using deneme.Dtos.Department;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace deneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly EF_DataContext _db;
        public DepartmentController(EF_DataContext dataContext)
        {
            _db = dataContext;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Department> GetDepartments()
        {
            var books = _db.Departments.ToList();

            return books;



        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            return _db.Departments.FirstOrDefault(s => s.Id == id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public string Post([FromBody] AddDepartmentDto department)
        {
            if (!ModelState.IsValid)
                return "Başarısız";

            var departmentToSave = new Department();

            departmentToSave.DepartmentName = department.DepartmentName;

            _db.Departments.Add(departmentToSave);
            _db.SaveChanges();

            return "Ekleme başarılı";
        }


        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public string PutAsync(int id, [FromBody] UpdateDepartmentDto department)
        {
            var departmentFromDB = _db.Departments.FirstOrDefault(s => s.Id == id);

            if (departmentFromDB == null) return "Departman Bulunamadı";

            departmentFromDB.DepartmentName = department.DepartmentName;

            _db.Departments.Update(departmentFromDB);
            _db.SaveChanges();

            return "Güncelleme başarılı";


        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           
            var department = await _db.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _db.Departments.Remove(department);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
