using ASP.Net02.Models;

namespace ASP.NET02.ViewModel
{
    public class StuDeptViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int DepartmentId { get; set; }

        public List<Department> DeptList { get; set; }
    }
}
