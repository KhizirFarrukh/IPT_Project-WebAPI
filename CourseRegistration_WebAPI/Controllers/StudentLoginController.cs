using CourseRegistration_WebAPI.Data;
using CourseRegistration_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistration_WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentLoginController : ControllerBase
    {
        private readonly CourseRegistrationDbContext dbContext;
        public StudentLoginController(CourseRegistrationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStudentLogin([FromRoute] string id)
        {
            return Ok(await this.dbContext.StudentLogins.FirstOrDefaultAsync(login => login.studentID == id));
        }

        [HttpPut]
        public async Task<IActionResult> AddStudentLogin([FromBody] StudentLogin login)
        {
            await this.dbContext.StudentLogins.AddAsync(login);
            await this.dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(AddStudentLogin), new { login.studentID }, login);
        }

        [HttpPost]
        public async Task<IActionResult> VerifyStudentLogin([FromBody] StudentLogin login)
        {
            var student = await this.dbContext.StudentLogins.FirstOrDefaultAsync(x => x.studentID == login.studentID);
            if(student == null)
            {
                return Unauthorized();
            }
            else if(student.password == login.password)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
