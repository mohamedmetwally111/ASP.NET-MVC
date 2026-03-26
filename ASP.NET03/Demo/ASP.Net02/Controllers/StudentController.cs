using ASP.Net02.Models;
using ASP.NET02.Models;
using ASP.NET02.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net02.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentbl = new StudentBL();
        DepartmentBL departmentbl = new DepartmentBL();

        //   /student/ShowAll  
        public IActionResult ShowAll()
        {

            List<Student> students=studentbl.GetAll();
            return View("ShowAll", students);

        }

        //    /Student/ShowDetails?id=3 
        public IActionResult ShowDetails(int id)
        {
            Student students = studentbl.GetById(id);
            return View("ShowDetails", students);
        }

    }
}
