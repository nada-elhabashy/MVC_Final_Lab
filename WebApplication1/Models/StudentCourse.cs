using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
	public class StudentCourse
	{
		[ForeignKey("StudentNavigation")]
		public int StdId { get; set; }
		[ForeignKey("CourseNavigation")]
		public int CrsId { get; set; }
		public int Degree { get; set; }
		public virtual Student StudentNavigation { get; set; }
		public virtual Course CourseNavigation { get; set; }
	}
}
