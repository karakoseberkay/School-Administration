using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace deneme.EfCore
{
    [Table(nameof(Teacher))]
    public class Teacher
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public string Name { get; set; } = string.Empty;
              
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }

    }
}
