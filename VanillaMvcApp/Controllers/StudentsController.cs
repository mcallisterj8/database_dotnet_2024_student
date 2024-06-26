using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VanillaMvcApp.Data;
using VanillaMvcApp.Models;

namespace VanillaMvcApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context) {
            _context = context;
        }

        // api/students
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents() {            
            return Ok(await _context.Students.ToListAsync());
        }

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
