using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.repos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        ITIDbContext db = new ITIDbContext();
        DeptRepo deptRepo = new DeptRepo();
        StudentRepo studentRepo = new StudentRepo();
        public IActionResult Index()
        {
            var departments = db.Departments.ToList();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Department());
        }
		[HttpPost]
		public IActionResult Create(Department dept)
        {
            if (dept.DeptId == 0 || dept.DeptName == null)
            {
                return View("Create", dept);
            }
            db.Departments.Add(dept);
            db.SaveChanges();
            return RedirectToAction("Index"); 
 }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(deptRepo.GetById(id.Value));
        }


        [HttpGet]
		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			var dept = db.Departments.FirstOrDefault(d => d.DeptId == id);
			if (dept == null)
			{
				return NotFound();
			}
			return View(dept);
		}
		
		[HttpPost]
		public IActionResult Edit(Department dept, int id)
		{
			if (dept.DeptId == 0 || dept.DeptName == null)
			{
				return View(dept);
			}
			db.Departments.Update(dept);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			var dept = db.Departments.FirstOrDefault(d => d.DeptId == id);
			if (dept == null)
			{
				return NotFound();
			}
			return View(dept);
		}
		/*[HttpPost]
		public IActionResult Delete(int id)
		{
			var dept = db.Departments.FirstOrDefault(d => d.DeptId == id);
			if (dept == null)
			{
				return NotFound();
			}
			db.Departments.Remove(dept);
			db.SaveChanges();
			return RedirectToAction("Index");
		}*/

		[ActionName("Delete")]
		[HttpPost]
		public IActionResult DeleteConfirmed(int id)
		{
			var dept = db.Departments.FirstOrDefault(d => d.DeptId == id);
			if (dept == null)
			{
				return NotFound();
			}
			db.Departments.Remove(dept);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
