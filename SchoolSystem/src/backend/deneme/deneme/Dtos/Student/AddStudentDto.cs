namespace deneme.Dtos.Student
{
    public class AddStudentDto // Data Transfer Object
    {
        public AddStudentDto()
        {
            CreatedDate = DateTime.Now;
        }

        public string Name { get; set; } = string.Empty;

        public int? DepartmentId { get; set; }

        public DateTime CreatedDate { get; protected set; }
    }
}
