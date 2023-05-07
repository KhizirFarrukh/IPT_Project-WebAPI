using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseRegistration_WebAPI.Models
{
    [PrimaryKey(nameof(id))]
    public class CoreCourse
    {
        //[ForeignKey("theoryCourse")]
        public Guid id { get; set; }
        //public virtual TheoryCourse theoryCourse { get; set; }

        //[ForeignKey("coreCourse")]
        public Guid prevChainID { get; set; }
        //public virtual CoreCourse coreCourse { get; set; }
    }
}
