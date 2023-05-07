using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseRegistration_WebAPI.Models
{
    [PrimaryKey(nameof(id))]
    public class Student
    {
        public string id { get; set; }
        public string name { get; set; }

        //[ForeignKey("section")]
        public Guid sectionID { get; set; }
        //public virtual Section section { get; set; }

        public int batchYear { get; set; }
    }
}
