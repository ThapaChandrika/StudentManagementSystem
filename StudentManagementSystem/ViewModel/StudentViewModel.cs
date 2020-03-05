using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.ViewModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter the Name ")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the  FatherName ")]
        [DataType(DataType.Text)]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Select the  Gender ")]
        [DataType(DataType.Text)]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter the  Address ")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter the  EmailAddress ")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter the  PhoneNo ")]
        [Display(Name = "PhoneNo")]
        public int? PhoneNo { get; set; }

        [Required(ErrorMessage = "Enter the  DOB ")]
        [Display(Name = "Date of Birth")]       
        
        public DateTime DOB { get; set; }
            
        public string ScholarshipId { get; set; }

        [Display(Name ="Scholarship Type")]        
        public string ScholarshipType { get; set; }

        public int FacultyId { get; set; }
        [Display(Name ="Faculty")]
        public string FacultyName { get; set; }

    }
}
