using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseRegistration_WebAPI.Models
{
    [PrimaryKey(nameof(studentID),nameof(courseLogID))]
    public class RegisteredCourse
    {
        //[ForeignKey("student")]
        public string studentID { get; set; }
        //public virtual Student student { get; set; }

        //[ForeignKey("courseLog")]
        public Guid courseLogID { get; set; }
        //public virtual CourseLog courseLog { get; set; }

        public string status { get; set; }
    }
}
