namespace deneme.Dtos.Teacher
{
    public class AddTeacherDto // Data Transfer Object
    {
        public string Name { get; set; } = string.Empty;

        public int? DepartmentId { get; set; }
    }
}