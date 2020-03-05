using StudentManagementSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly StudentContext context;
        public FacultyRepository(StudentContext context)
        {
            this.context = context;
        }

        public Faculty Add(Faculty faculty)
        {
            context.Faculty.Add(faculty);
            context.SaveChanges();
            return faculty;
        }

        public Faculty Delete(int id)
        {
            Faculty faculty = context.Faculty.Find(id);
            if (faculty != null)
            {
                context.Faculty.Remove(faculty);
                context.SaveChanges();
            }
            return faculty;
        }

        public IEnumerable<Faculty> GetAllFaculties()
        {
            return context.Faculty;
        }

        public Faculty GetFaculty(int id)
        {
            return context.Faculty.Find(id);
        }

        public Faculty Update(Faculty facultyChanges)
        {
            var employee = context.Faculty.Attach(facultyChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return facultyChanges;
        }
    }
}
