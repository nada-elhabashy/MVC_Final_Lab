using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class DepartmentCourseController : Controller
	{
        ITIDbContext db = new ITIDbContext();
        public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult ShowCoursesByDept(int id)
		{
            var dept = db.Departments.Include(d => d.Courses)
				.FirstOrDefault(d =>d.DeptId == id);
            return View(dept);

		}
		[HttpPost]
		public IActionResult ManageDeptCourses(int deptId, List<int> coursesToAdd,List<int> coursesToRemove)
		{
			//get department
			var dept = db.Departments.Include(d => d.Courses).FirstOrDefault(d => d.DeptId == deptId);
			foreach (var item in coursesToRemove)
			{
				//remove course from department
				Course course = dept.Courses.FirstOrDefault(c => c.CrsId == item);
				dept.Courses.Remove(course);
			}
			foreach (var item in coursesToAdd)
			{
				//add course to department
				Course course = dept.Courses.FirstOrDefault(c => c.CrsId == item);
				dept.Courses.Add(course);
			}
			db.SaveChanges();
			return RedirectToAction("Index", "Departments");
		}
	}
}