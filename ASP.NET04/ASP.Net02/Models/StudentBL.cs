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

        public void AddStu(Student StuAdd)
        {
            context.Students.Add(StuAdd);
            context.SaveChanges();
        }

        public void EditStu()
        {
            context.SaveChanges();
        }

        public void DeleteStu(Student RmStu)
        {
            context.Students.Remove(RmStu);
            context.SaveChanges();
        }
    }
}
