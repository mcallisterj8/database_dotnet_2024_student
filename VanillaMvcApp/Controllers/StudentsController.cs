using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VanillaMvcApp.Data;
using VanillaMvcApp.Models;
using VanillaMvcApp.Models.Dtos;

namespace VanillaMvcApp.Controllers {
    // api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context) {
            _context = context;
        }
        
        // api/students
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents() {
            // Get the data from the database
           var students = await _context.Students
                .Include(s => s.Courses)
                    .ThenInclude(c => c.Instructor)
                .Include(s => s.Courses)
                    .ThenInclude(c => c.Department)
                .ToListAsync();
            
            // Fill DTOs
            var studentDtos = students.Select(s => new StudentDto {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                JoiningDate = s.JoiningDate,
                Courses = s.Courses.Select(c => new CourseDto {
                    Id = c.Id,
                    Name = c.Name,
                    Instructor = c.Instructor,
                    Department = c.Department,
                }).ToList()
            } ).ToList();

            return Ok(studentDtos);
        }

        // api/students
        // [HttpGet("")]
        // public async Task<ActionResult<IEnumerable<Student>>> GetStudents() {            
        //     var res = await _context.Students.ToListAsync();
        //     // var res = await _context.Students
        //     //             .Include(s => s.Courses).ToListAsync();
            
        //     // foreach(var student in res) {
        //     //     Console.WriteLine(student.LastName);

        //     //     foreach(var course in student.Courses) {
        //     //         Console.WriteLine(course.Name);
        //     //     }
        //     //     Console.WriteLine("==============================");
        //     // }

        //     return Ok(res);
        // }

        // api/students/8
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id) {
            var student = await _context.Students
                .FindAsync(id);

            if(null == student) {
                return NotFound();
            }

            return Ok(student);
        }

    }
}
