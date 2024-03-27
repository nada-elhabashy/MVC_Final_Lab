using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.repos
{
    public interface IStudentRepo
    {
        List<Student> GetAllStudents();
        void AddStudent(Student student);
        Student GetStudentById(int id);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        List<Department> GetAllDepartments();
        void UpdateStudentImg(Student student);
    }
    public class StudentRepo : IStudentRepo
    {
        private readonly ITIDbContext db;

        public StudentRepo(ITIDbContext dbContext)
        {
            db = dbContext;
        }

        public StudentRepo()
        {
        }

        public void UpdateStudentImg(Student student)
        {
            try
            {
                var existingStudent = db.Students.Find(student.Id);
                if (existingStudent != null)
                {
                    existingStudent.StdImg = student.StdImg;
                    db.SaveChanges();
                }
            }
            catch
            {
            throw;
            }
        }
        public List<Student> GetAllStudents()
        {
            return db.Students.Include("Department").ToList();
        }
        public void AddStudent(Student student)
        {
            try
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public Student GetStudentById(int id)
        {
            return db.Students.Find(id);
        }
        public void UpdateStudent(Student student)
        {
            try
            {
                var existingStudent = db.Students.Find(student.Id);
                if (existingStudent != null)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.DeptNo = student.DeptNo;
                    db.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }
        public void DeleteStudent(int id)
        {
            try
            {
                var student = db.Students.Find(id);
                if (student != null)
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }
        public List<Department> GetAllDepartments()
        {
            return db.Departments.ToList();
        }

       
    }

}
