namespace ASP.Net02.Models
{
    public class StuCrsRe
    {
        public int Grade { get; set; }

        public int StudentId { get; set; }
        public Student Students { get; set; }



        public int CourseId { get; set; }
        public Course Courses { get; set; }
    }
}
