using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseRegistration_WebAPI.Models
{
    [PrimaryKey(nameof(studentID))]
    public class StudentLogin
    {
        //[ForeignKey("student")]
        public string studentID { get; set; }
        //public virtual Student student { get; set; }

        public string password { get; set; }
    }
}
