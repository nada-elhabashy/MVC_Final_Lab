using WebApplication1.Models;

namespace WebApplication1.repos
{
    public class DeptMockRepo
    {
        static List<Department> depts = new List<Department>
 {
 new Department{DeptId=1,DeptName="IT",Capacity=100,Status=true},
 new Department{DeptId=2,DeptName="CS",Capacity=100,Status=true},
 new Department{DeptId=3,DeptName="IS",Capacity=100,Status=true},
 new Department{DeptId=4,DeptName="SW",Capacity=100,Status=true},
 };
        public List<Department> GetAll()
        {
            return depts;
        }
        public Department GetById(int id)
        {
            return depts.FirstOrDefault(d => d.DeptId == id);
        }
        public void Add(Department dept)
        {
            depts.Add(dept);
        }
        public void Delete(int id)
        {
            Department dept = GetById(id);
            dept.Status = false;
        }
        public void Update(Department dept)
        {
            var model = depts.FirstOrDefault(d => d.DeptId == dept.DeptId);
            model.DeptName = dept.DeptName;
            model.Status = dept.Status;
            model.Capacity = dept.Capacity;
        }

    }
}
