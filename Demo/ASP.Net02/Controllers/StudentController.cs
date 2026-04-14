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

        public IActionResult Add()
        {
            List<Department> department = departmentbl.ShowAll();

            StuDeptViewModel stuDept = new StuDeptViewModel()
            {
                DeptList = department
            };

            return View("Add", stuDept);
        }

        public IActionResult AddSave(Student stu)
        {
            if(stu !=null)
            {
                studentbl.AddStu(stu);
                return RedirectToAction(nameof(ShowAll));
            }
            return View("Add", stu);
        }


        public IActionResult Edit(int id)
        {
            Student stu=studentbl.GetById(id);
            List<Department> Dept = departmentbl.ShowAll();

            StuDeptViewModel StuDept = new StuDeptViewModel()
            {
                Id = stu.Id,
                Name = stu.Name,
                Age = stu.Age,
                DepartmentId = stu.DepartmentId,
                DeptList = Dept
            };

            return View("Edit", StuDept);
        }

        public ActionResult EditSave(StuDeptViewModel NewStu)
        {
           if(NewStu.Name != null)
            {
                Student OldStu = studentbl.GetById(NewStu.Id);

                OldStu.Name = NewStu.Name;
                OldStu.Age = NewStu.Age;
                OldStu.DepartmentId = NewStu.DepartmentId;
                studentbl.EditStu();

                return RedirectToAction(nameof(ShowAll));
            }

           return View("Edit", NewStu);
            
        }

        public IActionResult Delete(int id)
        {
            Student stu = studentbl.GetById(id);
            return View("Delete", stu);
        }

        public IActionResult DeleteAction(int id,Student stu)
        {
            //Student stu=studentbl.GetById(id);
            if(stu !=null)
            {
                studentbl.DeleteStu(stu);
                return RedirectToAction(nameof(ShowAll));
            }
            return NotFound();
        }
    }


}
