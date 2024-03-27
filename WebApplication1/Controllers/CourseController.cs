using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Instructor, Admin")]
    public class CourseController : Controller
    {
        ITIDbContext db = new ITIDbContext();
        public IActionResult Index()
        {
            var courses = db.Courses.ToList();
            return View(courses);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View(new Course());
        }
        [HttpPost]
        public IActionResult Create(Course crs)
        {
            if(crs.CrsId==0||crs.CrsName==null)
            {
                return View(crs);
            }
            db.Courses.Add(crs);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
