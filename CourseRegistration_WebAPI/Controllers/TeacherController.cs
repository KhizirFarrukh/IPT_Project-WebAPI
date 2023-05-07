using CourseRegistration_WebAPI.Data;
using CourseRegistration_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistration_WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly CourseRegistrationDbContext dbContext;
        public TeacherController(CourseRegistrationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            return Ok(await this.dbContext.Teachers.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTeacherByID([FromRoute] Guid id)
        {
            return Ok(await this.dbContext.Teachers.FirstOrDefaultAsync(teacher => teacher.id == id));
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher([FromBody] Teacher teacher)
        {
            teacher.id = Guid.NewGuid();
            await this.dbContext.Teachers.AddAsync(teacher);
            await this.dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(AddTeacher), new { teacher.id }, teacher);
        }
    }
}
