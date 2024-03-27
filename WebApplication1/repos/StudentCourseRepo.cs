using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.repos
{

    public interface IRepoStudentCourse
    {
        public List<StudentCourse> getByCourseId(int courseId);
        public List<StudentCourse> getByStudentId(int studentId);
        public List<StudentCourse> getAll();
        public StudentCourse getByIds(int courseId, int studentId);
        public void Add(StudentCourse studentCourse);
        public void Delete(int courseId, int StudentId);
        //public void UpdateGrade(StudentCourse obj, int Grade);

    }
    public class StudentCourseRepo:IRepoStudentCourse
    {
        ITIDbContext db;
        public StudentCourseRepo(ITIDbContext _db)
        {
            db = _db;
        }
        public void Add(StudentCourse studentCourse)
        {
            db.Add(studentCourse);
            db.SaveChanges();
        }

        public void Delete(int courseId, int StudentId)
        {
            var obj = db.StudentCourses.FirstOrDefault(a => a.CrsId == courseId && a.StdId == StudentId);
            db.Remove(obj);
            db.SaveChanges();
        }

        public List<StudentCourse> getAll()
        {
            return db.StudentCourses.ToList();
        }

        public List<StudentCourse> getByCourseId(int courseId)
        {
            return db.StudentCourses.Where(a => a.CrsId == courseId).ToList();
        }

        public StudentCourse getByIds(int courseId, int studentId)
        {
            return db.StudentCourses.FirstOrDefault(a => a.CrsId == courseId && a.StdId == studentId);
        }

        public List<StudentCourse> getByStudentId(int studentId)
        {
            return db.StudentCourses.Where(a => a.StdId == studentId).ToList();
        }

       /* public void UpdateGrade(StudentCourse obj, int Grade)
        {
            var objF = db.StudentCourses.FirstOrDefault(a => a.CrsId == obj.CrsId && a.StdId == obj.StdId);
            objF.Grade = Grade;
            db.SaveChanges();
        }*/
    }
}

