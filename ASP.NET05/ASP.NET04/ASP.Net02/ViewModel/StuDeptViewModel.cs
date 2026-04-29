using ASP.Net02.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET02.ViewModel
{
    public class StuDeptViewModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]

        public string? Name { get; set; }

        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]

        public int Age { get; set; }

        [Required(ErrorMessage = "Department is required")]

        public int DepartmentId { get; set; }

        public List<SelectListItem>? DeptList { get; set; }
    }
}
