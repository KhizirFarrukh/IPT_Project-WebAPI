using CourseRegistration_WebAPI.Data;
using CourseRegistration_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistration_WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly CourseRegistrationDbContext dbContext;
        public SectionController(CourseRegistrationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetSections()
        {
            return Ok(await this.dbContext.Sections.OrderBy(section => section.semesterNo).ThenBy(section => section.postfixCharacter).ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSectionByID([FromRoute] Guid id)
        {
            return Ok(await this.dbContext.Sections.FirstOrDefaultAsync(section => section.id == id));
        }

        [HttpGet]
        [Route("Dept/{deptID}")]
        public async Task<IActionResult> GetSectionByDeptID([FromRoute] Guid deptID)
        {
            return Ok(await this.dbContext.Sections.Where(section => section.deptID == deptID).ToArrayAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddSection([FromBody] Section section)
        {
            section.id = Guid.NewGuid();
            await this.dbContext.Sections.AddAsync(section);
            await this.dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(AddSection), new { section.id }, section);
        }
    }
}
