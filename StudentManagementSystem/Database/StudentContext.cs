using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Database
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Student> Student { get; set; }      

        public DbSet<Scholarship> Scholarship { get; set; }
    }
}
