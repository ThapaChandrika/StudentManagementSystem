using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Faculty
    {
        [Key]
        [ForeignKey("Student")]
        public int Id { get; set; }
        [Display(Name = "Faculty")]
        [Required]
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}
