using System.ComponentModel.DataAnnotations;

namespace ASP.Net02.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="name is require")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "MgrName is require")]
        public string MgrName { get; set; }


        public List<Teacher> Teachers { get; set; }

        public List<Course> Courses { get; set; }

        public List<Student> Students { get; set; }



    }
}
