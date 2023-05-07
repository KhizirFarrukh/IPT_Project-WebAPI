using CourseRegistration_WebAPI.Data;
using CourseRegistration_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistration_WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredCoursesController : ControllerBase
    {
        private readonly CourseRegistrationDbContext dbContext;
        public RegisteredCoursesController(CourseRegistrationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegisteredCourses()
        {
            return Ok(await this.dbContext.RegisteredCourses.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRegisteredCourseByID([FromRoute] Guid id)
        {
            return Ok(await this.dbContext.RegisteredCourses.FirstOrDefaultAsync(registeredCourse => registeredCourse.courseLogID == id));
        }

        //[HttpPost]
        //public async Task<IActionResult> AddRegisteredCourse([FromBody] RegisteredCourse registeredCourse)
        //{
        //    await this.dbContext.RegisteredCourses.AddAsync(registeredCourse);
        //    await this.dbContext.SaveChangesAsync();

        //    return CreatedAtAction(nameof(AddRegisteredCourse), new { registeredCourse.id }, registeredCourse);
        //}
    }
}
