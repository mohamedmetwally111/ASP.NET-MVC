using ASP.Net02.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net02.Models
{
    public class StudentBL
    {
        CompanyDbContext context=new CompanyDbContext();

        public List<Student> GetAll()
        {
            return context.Students.Include(s=>s.Departments).ToList();
        }

        public Student GetById(int id)
        {
            return context.Students.Include(s => s.Departments).FirstOrDefault(s => s.Id == id);
        }
    }
}
