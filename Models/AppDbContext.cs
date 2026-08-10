using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentManager.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var depts = new List<Department>
            {
                new Department {DeptId = 1, Name = "IT"},
                new Department {DeptId = 2, Name = "CS"},
                new Department {DeptId = 3, Name = "IS"},
                new Department {DeptId = 4, Name = "AI"}
            };

            var stds = new List<Student>
            {
                new Student {Id = 1,Name = "Ahmed", Age = 20, Address = "Alexandria", DeptId = 1, Email = "ahmed@gmail.com", Password = "123456"},
                new Student {Id = 2,Name = "Ali", Age = 24, Address = "Ismailia", DeptId = 1, Email = "ali@gmail.com", Password = "123456"},
                new Student {Id = 3,Name = "Mohamed", Age = 26, Address = "Cairo", DeptId = 1, Email = "mohamed@gmail.com", Password = "123456"},
                new Student {Id = 4,Name = "Salah", Age = 22, Address = "Ismailia", DeptId = 2, Email = "salah@gmail.com", Password = "123456"},
                new Student {Id = 5,Name = "Ziad", Age = 27, Address = "Sinai", DeptId = 2, Email = "ziad@gmail.com", Password = "123456"},
                new Student {Id = 6,Name = "Mahmoud", Age = 29, Address = "Ismailia", DeptId = 2, Email = "mahmoud@gmail.com", Password = "123456"},
                new Student {Id = 7,Name = "Osama", Age = 21, Address = "Sinai", DeptId = 3, Email = "osama@gmail.com", Password = "123456"},
                new Student {Id = 8,Name = "Ezz", Age = 20, Address = "Ismailia", DeptId = 3, Email = "ezz@gmail.com", Password = "123456"},
                new Student {Id = 9,Name = "Mazen", Age = 24, Address = "Cairo", DeptId = 4, Email = "mazen@gmail.com", Password = "123456"},
                new Student {Id = 10,Name = "Eid", Age = 24, Address = "Sinai", DeptId = 4, Email = "eid@gmail.com", Password = "123456"},
                new Student {Id = 11,Name = "Hagag", Age = 28, Address = "Ismailia", DeptId = 4, Email = "hagag@gmail.com", Password = "123456"},
                new Student {Id = 12,Name = "Abdelrahman", Age = 23, Address = "Cairo", DeptId = 4, Email = "abdelrahman@gmail.com", Password = "123456"},
            };

            modelBuilder.Entity<Department>().HasData(depts);
            modelBuilder.Entity<Student>().HasData(stds);

        }



    }
}