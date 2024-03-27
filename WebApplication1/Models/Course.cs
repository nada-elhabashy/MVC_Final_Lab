using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class Course
	{
		[Key]
		public int CrsId { get; set; }
		public string CrsName { get; set; }
		public int Duration { get; set; }
		public virtual List<Department> Departments { get; set; } = new List<Department> ();
		public virtual List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

	}
}
