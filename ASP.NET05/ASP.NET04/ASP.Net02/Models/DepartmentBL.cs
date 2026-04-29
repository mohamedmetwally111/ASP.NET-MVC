using ASP.Net02.Data.Contexts;
using ASP.Net02.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET02.Models
{
    public class DepartmentBL
    {
        CompanyDbContext DbContext=new CompanyDbContext();

        public List<Department> ShowAll()
        {
            return DbContext.Departments.Include(D=>D.Students).ToList();
        }
        public Department GetById(int id)
        {
            return DbContext.Departments.Include(D => D.Students).FirstOrDefault(D => D.Id == id);
        }

        public void AddDept(Department dept)
        {
            DbContext.Departments.Add(dept);
            DbContext.SaveChanges();
        }
    }
}
