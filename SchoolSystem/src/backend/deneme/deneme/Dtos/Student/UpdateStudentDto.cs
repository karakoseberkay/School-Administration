using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace deneme.Dtos.Student
{
    public class UpdateStudentDto
    {
        /*[Key]
        public int Id { get; set; }
        */
        public string Name { get; set; } = string.Empty;

        public int? DepartmentId { get; set; }

    }
}
