using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Student
    {
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

		public virtual List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

		public int DeptNo { get; set; }
        [ForeignKey("DeptNo")]
        public virtual Department DepartmentNavigation { get; set; }
       
        public string? StdImg { get; set; }
    }
}
