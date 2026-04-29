using ASP.Net02.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ASP.NET02.ViewModel
{
    public class StudentListViewModel
    {
        public List<Student> Students { get; set; }
        public string SearchTerm { get; set; }
        public int? SelectedDeptId { get; set; }
        public List<SelectListItem> DeptList { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
