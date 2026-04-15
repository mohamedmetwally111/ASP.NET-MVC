namespace ASP.Net02.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }



        public int DepartmentId { get; set; }
        public Department Departments { get; set; }


        public List<Teacher> Teachers { get; set; }


        public List<StuCrsRe> StudentResults { get; set; }

    }
}
