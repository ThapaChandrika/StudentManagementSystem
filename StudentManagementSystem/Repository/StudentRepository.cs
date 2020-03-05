using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext context;
        public StudentRepository(StudentContext context)
        {
            this.context = context;
        }

        public Student Add(Student student)
        {
            context.Student.Add(student);
            context.SaveChanges();
            return student;
        }

        public Student Delete(int id)
        {
            Student student = context.Student.Find(id);
            if (student != null)
            {
                context.Student.Remove(student);
                context.SaveChanges();
            }
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return context.Student.Include(f=> f.Faculty).Include(b=> b.Scholarship);
        }

        public Student GetStudent(int id)
        {
            return context.Student
                          .Include(f => f.Faculty)
                          .Include(b => b.Scholarship)
                          .SingleOrDefault(x => x.Id == id);
        }

        public Student Update(Student studentChanges)
        {
            var student = context.Student.Attach(studentChanges);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return studentChanges;
        }
    }
}
