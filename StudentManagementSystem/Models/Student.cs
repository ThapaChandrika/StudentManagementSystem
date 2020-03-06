using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Student
    {
       
        public int Id { get; set; }

        public string Name { get; set; }
     
        public string FatherName { get; set; }
       
        public string Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }
   
        public DateTime DOB { get; set; }


        [ForeignKey("ScholarshipId")]
        public string ScholarshipId { get; set; }
        public virtual Scholarship Scholarship { get; set; }
        
        [ForeignKey("FacultyId")]
        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }
        
    }
}
