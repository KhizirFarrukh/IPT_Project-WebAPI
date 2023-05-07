using Microsoft.EntityFrameworkCore;

namespace CourseRegistration_WebAPI.Models
{
    [PrimaryKey(nameof(id))]
    public class Department
    {
        public Guid id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }
}
