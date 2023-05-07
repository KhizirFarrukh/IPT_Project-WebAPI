using CourseRegistration_WebAPI.Data;
using CourseRegistration_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistration_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly CourseRegistrationDbContext dbContext;
        public DepartmentController(CourseRegistrationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            return Ok(await this.dbContext.Departments.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDepartmentByID([FromRoute] Guid id)
        {
            return Ok(await this.dbContext.Departments.FirstOrDefaultAsync(dept => dept.id == id));
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            department.id = Guid.NewGuid();
            await dbContext.Departments.AddAsync(department);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
