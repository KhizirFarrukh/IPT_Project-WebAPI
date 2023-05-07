using Microsoft.EntityFrameworkCore;

namespace CourseRegistration_WebAPI.Models
{
    [PrimaryKey(nameof(id))]
    public class Teacher
    {
        public Guid id { get; set; }
        public string name { get; set; }
    }
}
