using ASP.Net02.Models;
using ASP.NET02.Models;
using ASP.NET02.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ASP.NET02.Controllers
{
    public class DepartmentController : Controller

    {
        DepartmentBL departmentBL=new DepartmentBL();
        StudentBL studentbl = new StudentBL();

        // /Department/showAll
        public IActionResult showAll()
        {
            List<Department> department = departmentBL.ShowAll();
            return View("showAll", department);
        }

        // /Department/ShowDetails?id=3
        public IActionResult ShowDetails(int id)
        {
            Department department = departmentBL.GetById(id);
            return View("ShowDetails", department);
        }

        // /Department/DetailsWithStudent?id=3
        public IActionResult DetailsWithStudent(int id)
        {
            Department dept = departmentBL.GetById(id);
            List<Student> students = studentbl.GetAll();
            var res = students.Where(s => s.Age > 25)
                .Select(s => s.Name)
                .ToList();

            int count = dept.Students.Count();

            DepartmentViewModel VM = new DepartmentViewModel()
            {
                DeptName = dept.Name,
                StudentName = res,
                DepartmentState = count > 50 ? "Main" : "branch"
            };

            return View("DetailsWithStudent", VM);


        }



        public IActionResult Add()
        {
            return View("Add");
        }


        public IActionResult SaveAdd(Department DeptSet)
        {
            if(DeptSet.Name != null)
            {
                departmentBL.AddDept(DeptSet);
                return RedirectToAction(nameof(showAll));
            }
            return View("Add", DeptSet);
        }

    }
}
