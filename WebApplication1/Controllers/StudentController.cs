using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.repos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        ITIDbContext db = new ITIDbContext();
		DeptRepo deptRepo = new DeptRepo();
       // StudentRepo studentRepo = new StudentRepo();
       IStudentRepo studentRepo;
		public StudentController(IStudentRepo _studentRepo)
		{
			studentRepo = _studentRepo;
		}
            public IActionResult Index()
        {
			//var students = db.Students.Include(s => s.DepartmentNavigation).ToList();
			//return View(students);
			return View(deptRepo.GetAll());


		}
		[HttpGet]
		public IActionResult Create()
		{
			
			ViewBag.Departments = db.Departments.ToList();
			return View(new Student());
		}
		[HttpPost]
		/*public IActionResult Create(Student student)
		{
			if (student.Id == 0 || student.Name == null)
			{
				ViewBag.Departments = db.Departments.ToList();
				return View("Create",student);
			}
			db.Students.Add(student);
			db.SaveChanges();
			return RedirectToAction("Index");
		}*/
		[HttpPost]
		public IActionResult Create(Student student)
		{
			if (!ModelState.IsValid)
			{
				db.Students.Add(student);
				db.SaveChanges();
				return RedirectToAction("Index");

				// Model validation failed, return the form with validation errors
				//ViewBag.Departments = db.Departments.ToList();
				//return View("Create", student);
			}
			ModelState.AddModelError("", "invalid model data");
            ModelState.AddModelError("Name", "Name is required");
			return View();

            // Model validation succeeded, proceed with adding the student
            /*try
			{
				db.Students.Add(student);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				// Log or handle the exception accordingly
				ModelState.AddModelError("", "Error occurred while saving the student. Please try again.");
				ViewBag.Departments = db.Departments.ToList();
				return View("Create", student);
			}*/
        }
       




    }
}
