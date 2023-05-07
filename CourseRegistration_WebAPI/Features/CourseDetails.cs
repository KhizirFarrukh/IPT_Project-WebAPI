namespace CourseRegistration_WebAPI.Features
{
    public class CourseDetails
    {
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public Guid deptID { get; set; }
        public int creditHours { get; set; }
        public Guid coursePtr { get; set; }
        public bool isLabCourse { get; set; }
        public bool hasPrevChain { get; set; }
        public string courseType { get; set; }
    }
}
