using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Department
    {
        

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptId { get; set; }
        [Display(Name = "Department Name")]

        public string DeptName { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
         public virtual List<Course> Courses { get; set; } = new List<Course>();
    }
}
