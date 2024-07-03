namespace VanillaMvcApp.Models.Dtos;

public class StudentDto {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? JoiningDate { get; set; }
    public ICollection<CourseDto> Courses { get; set; } = new List<CourseDto>();
}