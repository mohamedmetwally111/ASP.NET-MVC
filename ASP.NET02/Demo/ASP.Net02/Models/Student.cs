namespace ASP.Net02.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int DepartmentId { get; set; }
        public Department Departments { get; set; }


        public List<StuCrsRe> CourseResults { get; set; }

    }
}
