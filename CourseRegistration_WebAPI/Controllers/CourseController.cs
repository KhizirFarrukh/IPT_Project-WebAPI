using CourseRegistration_WebAPI.Data;
using CourseRegistration_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using CourseRegistration_WebAPI.Features;
using Azure.Core;

namespace CourseRegistration_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseRegistrationDbContext dbContext;

        public CourseController(CourseRegistrationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(await this.dbContext.Courses.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCourseById([FromRoute] Guid id)
        {
            return Ok(await this.dbContext.Courses.FirstOrDefaultAsync(course => course.id == id));
        }

        [HttpGet]
        [Route("Dept/{deptID}")]
        public async Task<IActionResult> GetCourseBydeptID(Guid deptID)
        {
            return Ok(await this.dbContext.Courses.Where(course => course.deptID == deptID).ToArrayAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] CourseDetails details)
        {
            Course course = new Course
            {
                id = Guid.NewGuid(),
                code = details.CourseCode,
                name = details.CourseTitle,
                deptID = details.deptID,
                creditHours = details.creditHours
            };
            await this.dbContext.Courses.AddAsync(course);

            if(details.isLabCourse)
            {
                LabCourse lCourse = new LabCourse
                {
                    id = course.id,
                    theoryID = details.coursePtr
                };
                await this.dbContext.LabCourses.AddAsync(lCourse);
            }
            else
            {
                TheoryCourse tCourse = new TheoryCourse
                {
                    id = course.id,
                    type = details.courseType
                };
                await this.dbContext.TheoryCourses.AddAsync(tCourse);

                if (details.hasPrevChain)
                {
                    CoreCourse chainCourse = new CoreCourse
                    {
                        id = course.id,
                        prevChainID = details.coursePtr
                    };
                    await this.dbContext.CoreCourses.AddAsync(chainCourse);
                }
            }
            
            await this.dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
