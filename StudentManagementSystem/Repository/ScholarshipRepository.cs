using StudentManagementSystem.Database;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repository
{
    public class ScholarshipRepository : IScholarshipRepository
    {
        private readonly StudentContext context;
        public ScholarshipRepository(StudentContext context)
        {
            this.context = context;
        }

        public Scholarship Add(Scholarship scholarship)
        {
            context.Scholarship.Add(scholarship);
            context.SaveChanges();
            return scholarship;
        }

        public Scholarship Delete(string id)
        {
            Scholarship scholarship = context.Scholarship.Find(id);
            if (scholarship != null)
            {
                context.Scholarship.Remove(scholarship);
                context.SaveChanges();
            }
            return scholarship;
        }

        public IEnumerable<Scholarship> GetAllScholarshipType()
        {
            return context.Scholarship;
        }

        public Scholarship GetScholarshipType(string id)
        {
            return context.Scholarship.Find(id);
        }

        public Scholarship Update(Scholarship scholarshipChanges)
        {
            var scholarship = context.Scholarship.Attach(scholarshipChanges);
            scholarship.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return scholarshipChanges;
        }
    }
}
