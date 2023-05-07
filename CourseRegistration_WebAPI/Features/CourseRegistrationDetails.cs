using CourseRegistration_WebAPI.Models;

namespace CourseRegistration_WebAPI.Features
{
    public class CourseRegistrationDetails
    {
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public string CourseType { get; set; }
        public int CourseCredHrs { get; set; }
        public IDictionary<Section,Teacher> SectionTeachers { get; set; }
    }
}
