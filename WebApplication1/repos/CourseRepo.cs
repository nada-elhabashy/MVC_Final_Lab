using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.repos
{
    public interface IRepoCourse
    {
        public void Add(Course course);
        public void Update(Course course);
        public void Delete(int id);
        public List<Course> getAll();
        public Course getById(int id);
        public bool FindName(string name);

    }


    public class CourseRepo:IRepoCourse
    {

        ITIDbContext db;
        public CourseRepo(ITIDbContext context)
        {
            db = context;
        }
        public void Add(Course course)
        {
           // course.IsActive = true;
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = db.Courses.FirstOrDefault(a => a.CrsId == id);
            db.Remove(obj);
            db.SaveChanges();
        }

        public List<Course> getAll()
        {
            return db.Courses.ToList();
        }

        public Course getById(int id)
        {
            return db.Courses.FirstOrDefault(a => a.CrsId == id);
        }

        public void Update(Course course)
        {
            db.Courses.Update(course);
            db.SaveChanges();
        }
        public bool FindName(string name)
        {
            return db.Courses.Any(a => a.CrsName == name);
        }
    }
}

