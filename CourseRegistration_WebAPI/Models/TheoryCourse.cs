using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseRegistration_WebAPI.Models
{
    [PrimaryKey(nameof(id))]
    public class TheoryCourse
    {
        //[ForeignKey("course")]
        public Guid id { get; set; }
        //public virtual Course course { get; set; }

        public string type { get; set; }
    }
}
