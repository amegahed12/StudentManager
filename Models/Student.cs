using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManager.Models
{
    public class Student
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }

        public string? Address { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        [NotMapped]
        public string ConfirmPassword { get; set; }


        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public virtual Department? Department { get; set; }
    }
}