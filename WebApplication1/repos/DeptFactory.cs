

using WebApplication1.Models;

namespace WebApplication1.repos
{
    public class DeptFactory
    {
        static DeptRepo deptRepo = null;
        public static IRepository<Department> Create()
        {
            if (deptRepo == null)
            {
                deptRepo = new DeptRepo();
            }
            return (IRepository<Department>)deptRepo;
            
        }
    }
}
