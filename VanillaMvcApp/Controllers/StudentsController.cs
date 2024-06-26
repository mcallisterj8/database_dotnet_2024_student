using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VanillaMvcApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase {

        // api/students
        [HttpGet("")]
        public async Task<IActionResult> GetStudents() {            
            return Ok(new {hello = "world!"});
        }

        // api/students/8
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id) {
            return Ok(new {studentId = id});
        }

    }
}
