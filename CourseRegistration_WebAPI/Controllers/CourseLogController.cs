using CourseRegistration_WebAPI.Data;
using CourseRegistration_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseRegistration_WebAPI.Features;
using System.Dynamic;
using Azure.Core;
using System.Threading;

namespace CourseRegistration_WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseLogController : ControllerBase
    {
        private readonly CourseRegistrationDbContext dbContext;
        public CourseLogController(CourseRegistrationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseLogs()
        {
            //return Ok(await this.dbContext.CourseLogs.ToListAsync());
            var data = from cLog in dbContext.CourseLogs
                       join course in dbContext.Courses
                       on cLog.courseID equals course.id
                       join theory in dbContext.TheoryCourses
                       on course.id equals theory.id
                       join sec in dbContext.Sections
                       on cLog.sectionID equals sec.id
                       join dept in dbContext.Departments
                       on sec.deptID equals dept.id
                       join teacher in dbContext.Teachers
                       on cLog.teacherID equals teacher.id
                       select new
                       {
                           CourseLogID = cLog.id,
                           CourseCode = course.code,
                           CourseTitle = course.name,
                           CourseType = theory.type,
                           CourseCredHrs = course.creditHours,
                           sectionDept = dept.code,
                           semesterNo = sec.semesterNo,
                           sectionChar = sec.postfixCharacter,
                           teacherName = teacher.name
                       };

            //var courseData = (from cLog in dbContext.CourseLogs
            //           join course in dbContext.Courses
            //           on cLog.courseID equals course.id
            //           join theory in dbContext.TheoryCourses
            //           on course.id equals theory.id
            //           select new
            //           {
            //               CourseCode = course.code,
            //               CourseTitle = course.name,
            //               CourseType = theory.type,
            //               CourseCredHrs = course.creditHours
            //           }).Distinct();
            //dynamic data = new ExpandoObject();
            //foreach (var _course in courseData)
            //{
            //    var secData = from cLog in dbContext.CourseLogs
            //                  join course in dbContext.Courses
            //                  on cLog.courseID equals course.id
            //                  join sec in dbContext.Sections
            //                  on cLog.sectionID equals sec.id
            //                  join dept in dbContext.Departments
            //                  on sec.deptID equals dept.id
            //                  join teacher in dbContext.Teachers
            //                  on cLog.teacherID equals teacher.id
            //                  where course.code == _course.CourseCode
            //                  select new
            //                  {
            //                      CourseLogID = cLog.id,
            //                      sectionDept = dept.code,
            //                      semesterNo = sec.semesterNo,
            //                      sectionChar = sec.postfixCharacter,
            //                      teacherName = teacher.name
            //                  };
            //    data.courseData = _course;
            //    data.secData = secData;
            //}
            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCourseLogByID([FromRoute] Guid id)
        {
            return Ok(await this.dbContext.CourseLogs.FirstOrDefaultAsync(courseLog => courseLog.id == id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCourseLog([FromBody] CourseLog courseLog)
        {
            courseLog.id = Guid.NewGuid();
            courseLog.year = DateTime.Now.Year;
            await this.dbContext.CourseLogs.AddAsync(courseLog);
            await this.dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(AddCourseLog), new { courseLog.id }, courseLog);
        }

        [HttpDelete]
        [Route("{DeleteID}")]
        public async Task<IActionResult> DeleteCourseLog([FromRoute] Guid DeleteID)
        {
            var courseLog = dbContext.CourseLogs.Where(a => a.id == DeleteID).FirstOrDefault();
            if (courseLog == null)
            {
                return NotFound();
            }
            dbContext.Remove(courseLog);

            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
