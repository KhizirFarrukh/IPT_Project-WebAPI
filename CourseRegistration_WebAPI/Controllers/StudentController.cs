using CourseRegistration_WebAPI.Data;
using CourseRegistration_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistration_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly CourseRegistrationDbContext dbContext;
        public StudentController(CourseRegistrationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await dbContext.Students.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStudentById([FromRoute] string id)
        {
            return Ok(await this.dbContext.Students.FirstOrDefaultAsync(student => student.id == id));
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            await this.dbContext.Students.AddAsync(student);
            await this.dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentById), new { id = student.id }, student);
        }
    }
}
