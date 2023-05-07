using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseRegistration_WebAPI.Models
{
    [PrimaryKey(nameof(id))]
    public class Course
    {
        public Guid id { get; set; }
        public string code { get; set; }
        public string name { get; set; }

        //[ForeignKey("department")]
        public Guid deptID { get; set; }
        //public virtual Department department { get; set; }

        public int creditHours { get; set; }
    }
}
