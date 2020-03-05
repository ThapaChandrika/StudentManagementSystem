using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repository
{
    public interface IScholarshipRepository
    {
        Scholarship GetScholarshipType(string id);
        IEnumerable<Scholarship> GetAllScholarshipType();
        Scholarship Add(Scholarship scholarship);
        Scholarship Update(Scholarship scholarshipChanges);
        Scholarship Delete(string id);
    }
}
