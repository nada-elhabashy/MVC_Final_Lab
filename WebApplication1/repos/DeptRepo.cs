using Microsoft.EntityFrameworkCore.Storage;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.repos
{
    interface IDeptRepo
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Add(Department dept);
        void Delete(int id);
        void Update(Department dept);
    }

    public class DeptRepo: IDeptRepo
    {
        ITIDbContext db= new ITIDbContext();

        
        public DeptRepo(ITIDbContext _db)
        {
            db = _db;
        }

        public DeptRepo()
        {
        }

        public List<Department>GetAll()
        {
            return db.Departments.Where(d=>d.Status==true).ToList();
        }
        public Department GetById(int id)
        {
            return db.Departments.FirstOrDefault(d => d.DeptId == id);
        }
        public void Add(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();   
        }
        public void Delete(int id)
        {
            Department dept = new Department();
            dept.Status = false;
            db.SaveChanges();
        }
        public void update(Department Dept)
        {
            var model = db.Departments.FirstOrDefault(d => d.DeptId == Dept.DeptId);
            model.DeptName = Dept.DeptName;
            model.Status = Dept.Status;
            model.Capacity = Dept.Capacity;
            db.Departments.Update(Dept);

            db.SaveChanges();
        }

        public void Update(Department dept)
        {
            throw new NotImplementedException();
        }
    }
}
