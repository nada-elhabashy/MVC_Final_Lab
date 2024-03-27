using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ITIDbContext : DbContext
    {
        public ITIDbContext()
        {
        }

       /* public ITIDbContext(DbContextOptions options) : base(options)
        {

        }*/
       
            public ITIDbContext(DbContextOptions<ITIDbContext> options) : base(options)
            {
            }
        

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public  DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        /*	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=newDB;integrated security = true; trust server certificate = true");

                base.OnConfiguring(optionsBuilder);
            }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseLazyLoadingProxies();
           // optionsBuilder.UseSqlServer("Server=.;Database=newDB;integrated security = true; trust server certificate = true");
            ;
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(a =>
            {
                a.HasKey(c => new { c.CrsId, c.StdId });
            });
            modelBuilder.Entity<Student>().HasIndex(s => s.Name).IsUnique();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Student" },
                new Role { Id = 3, Name = "Instructor" }

                );
            });

        }

       

        
    }
}
