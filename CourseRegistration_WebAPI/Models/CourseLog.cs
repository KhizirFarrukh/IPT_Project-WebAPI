using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseRegistration_WebAPI.Models
{
    [PrimaryKey(nameof(id))]
    public class CourseLog
    {
        public Guid id { get; set; }

        //[ForeignKey("course")]
        public Guid courseID { get; set; }
        //public virtual Course course { get; set; }

        //[ForeignKey("teacher")]
        public Guid teacherID { get; set; }
        //public virtual Teacher teacher { get; set; }

        //[ForeignKey("section")]
        public Guid sectionID { get; set; }
        //public virtual Section section { get; set; }

        public int year { get; set; }
        public string status { get; set; }
    }
}
