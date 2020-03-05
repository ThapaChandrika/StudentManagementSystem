using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public interface IFacultyRepository
    {
        Faculty GetFaculty(int id);
        IEnumerable<Faculty> GetAllFaculties();
        Faculty Add(Faculty faculty);
        Faculty Update(Faculty facultyChanges);
        Faculty Delete(int id);
    }
}
