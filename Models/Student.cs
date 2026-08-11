using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManager.Models
{
    public class Student
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [MinLength(3, ErrorMessage = "The Name field must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "The Name field must be at most 50 characters long.")]
        public required string Name { get; set; }

        [Range(10, 70, ErrorMessage = "The Age field must be between 10 and 70.")]
        public int Age { get; set; }


        [StringLength(50, ErrorMessage = "The Address field must be at most 50 characters long.", MinimumLength = 2)]
        public string? Address { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email")]
        [StringLength(50, ErrorMessage = "The Email field must be at most 50 characters long.", MinimumLength = 5)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [MaxLength(50, ErrorMessage = "The Password field must be at most 50 characters long.")]
        [MinLength(6, ErrorMessage = "The Password field must be at least 6 characters long.")]
        [Required(ErrorMessage = "The Password field is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "The Password field must contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }


        [NotMapped]
        [Compare("Password", ErrorMessage = "The Password and Confirm Password fields do not match.")]
        [DataType(DataType.Password)]
        [MaxLength(50, ErrorMessage = "The Confirm Password field must be at most 50 characters long.")]
        [MinLength(6, ErrorMessage = "The Confirm Password field must be at least 6 characters long.")]
        [Required(ErrorMessage = "The Confirm Password field is required.")]
        public string ConfirmPassword { get; set; }


        [ForeignKey("Department")]
        [DisplayName("Department")]
        public int DeptId { get; set; }
        public virtual Department? Department { get; set; }
    }
}