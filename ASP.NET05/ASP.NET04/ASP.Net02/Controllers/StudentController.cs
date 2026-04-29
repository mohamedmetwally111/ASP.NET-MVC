using ASP.Net02.Models;
using ASP.NET02.Models;
using ASP.NET02.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.Net02.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentbl = new StudentBL();
        DepartmentBL departmentbl = new DepartmentBL(); 

        //   /student/ShowAll  
        public IActionResult ShowAll(string search, int? deptId, int page = 1)
        {
            int pageSize = 5;
            List<Student> students = studentbl.GetAll();

            // Filter by search term
            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(s => s.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Filter by department
            if (deptId.HasValue)
            {
                students = students.Where(s => s.DepartmentId == deptId).ToList();
            }

            int totalStudents = students.Count;
            int totalPages = (int)Math.Ceiling(totalStudents / (double)pageSize);

            // Pagination
            var paginatedStudents = students
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var viewModel = new StudentListViewModel
            {
                Students = paginatedStudents,
                SearchTerm = search,
                SelectedDeptId = deptId,
                CurrentPage = page,
                TotalPages = totalPages,
                DeptList = departmentbl.ShowAll().Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name,
                    Selected = d.Id == deptId
                }).ToList()
            };

            return View("ShowAll", viewModel);
        }

        //    /Student/ShowDetails?id=3 
        public IActionResult ShowDetails(int id)
        {
            Student students = studentbl.GetById(id);
            return View("ShowDetails", students);
        }

        public IActionResult Add()
        {

            List<Department> dept=departmentbl.ShowAll();

            StuDeptViewModel stuDept = new StuDeptViewModel()
            {
                DeptList=dept.Select(d=>new SelectListItem
                {
                    Value=d.Id.ToString(),
                    Text=d.Name
                }
                ).ToList()
            };

            //ViewBag.deps = new SelectList(studentbl.GetAllDepartments(), "Id", "Name");

            //List<Department> department = departmentbl.ShowAll();

            //StuDeptViewModel stuDept = new StuDeptViewModel()
            //{

            //    DeptList = department
            //};

            return View(stuDept);
        }

        [HttpPost]
        public IActionResult AddSave(StuDeptViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Student stu = new Student()
                {
                    Name = vm.Name,
                    Age = vm.Age,
                    DepartmentId = vm.DepartmentId
                };

                studentbl.AddStu(stu);
                return RedirectToAction(nameof(ShowAll));
            }

            vm.DeptList = departmentbl.ShowAll()
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList();

            return View("Add", vm);
        }


        public IActionResult Edit(int id)
        {
            Student stu = studentbl.GetById(id);
            //ViewBag.deps = new SelectList(studentbl.GetAllDepartments(), "Id", "Name", stu.DepartmentId);

            List<Department> Dept = departmentbl.ShowAll();

            StuDeptViewModel StuDept = new StuDeptViewModel()
            {
                Id = stu.Id,
                Name = stu.Name,
                Age = stu.Age,
                DepartmentId = stu.DepartmentId,
                DeptList=Dept.Select(d=> new SelectListItem
                {
                    Value=d.Id.ToString(),
                    Text=d.Name,
                }
                ).ToList()

                //DeptList = Dept.Select(d => new SelectListItem
                //{
                //    Value = d.Id.ToString(),
                //    Text = d.Name
                //}).ToList()
            };

            return View("Edit", StuDept);
        }

        public ActionResult EditSave(StuDeptViewModel NewStu)
        {
           if(ModelState.IsValid)
            {
                Student OldStu = studentbl.GetById(NewStu.Id);

                OldStu.Name = NewStu.Name;
                OldStu.Age = NewStu.Age;
                OldStu.DepartmentId = NewStu.DepartmentId;
                studentbl.EditStu();

                return RedirectToAction(nameof(ShowAll));
            }
            NewStu.DeptList = departmentbl.ShowAll()
                 .Select(d => new SelectListItem
                 {
                     Value = d.Id.ToString(),
                     Text = d.Name
                 }).ToList();
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
