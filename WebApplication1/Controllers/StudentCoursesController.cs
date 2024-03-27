using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class StudentCoursesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		ITIDbContext db = new ITIDbContext();
		[HttpGet]
		public IActionResult UpdateStudentDegrees(int deptId, int crsId)
		{
			var model = db.Departments.Include(d => d.Students).FirstOrDefault(d => d.DeptId == deptId);
			return View(model);
		}
		[HttpPost]
		public IActionResult UpdateStudentDegrees(int deptId, int crsId, Dictionary<int, int> stdDegree)
		{
			foreach (var item in stdDegree)
			{
				//we need to check if the student is already in database or not
				var model = db.StudentCourses.FirstOrDefault(sc => sc.StdId == item.Key && sc.CrsId == crsId);
				if (model != null)
				{
					model.Degree = item.Value;
				}
				else
				{
					db.StudentCourses.Add(new StudentCourse
					{
						StdId = item.Key,
						CrsId = crsId,
						Degree = item.Value
					});
				}
			}
			db.SaveChanges();
			return RedirectToAction("Index", "Departments");


		}
	}
}