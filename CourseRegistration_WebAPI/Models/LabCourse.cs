using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseRegistration_WebAPI.Models
{
    [PrimaryKey(nameof(id))]
    public class LabCourse
    {
        //[ForeignKey("course")]
        public Guid id { get; set; }
        //public virtual Course course { get; set; }

        //[ForeignKey("theoryCourse")]
        public Guid theoryID { get; set; }
        //public virtual TheoryCourse theoryCourse { get; set; }
    }
}
