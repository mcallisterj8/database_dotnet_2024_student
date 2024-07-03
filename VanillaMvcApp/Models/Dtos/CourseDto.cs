namespace VanillaMvcApp.Models.Dtos;

public class CourseDto {
    public int Id { get; set; }
    public string Name { get; set; }
    public Instructor? Instructor { get; set; }
    public Department? Department { get; set; }
}