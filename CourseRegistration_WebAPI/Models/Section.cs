using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseRegistration_WebAPI.Models
{
    [PrimaryKey(nameof(id))]
    public class Section
    {
        public Guid id { get; set; }

        //[ForeignKey("department")]
        public Guid deptID { get; set; }
        //public Department department { get; set; }

        public char postfixCharacter { get; set; }
        public int semesterNo { get; set; }
    }
}
