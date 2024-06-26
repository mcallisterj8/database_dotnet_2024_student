
using System.ComponentModel.DataAnnotations;

namespace VanillaMvcApp.Models;

public class Department {
    [Key]
    public int Id { get; set;}
    [Required]
    public required string Name { get; set;}
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
