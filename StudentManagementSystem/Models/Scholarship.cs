using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Scholarship : BaseEntity
    {
        [Required(ErrorMessage = "Scholarship type cannot be empty")]
        [Display(Name = "Scholarship Type")]
        public string Type { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
