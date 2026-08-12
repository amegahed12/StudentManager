using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManager.Models
{
    public class User
    {

        [Key]
        public int UserID;


        [Required(ErrorMessage = "The First Name field is required.")]
        [MinLength(3, ErrorMessage = "The First Name field must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "The First Name field must be at most 50 characters long.")]

        public required string FirstName;

        [Required(ErrorMessage = "The First Name field is required.")]
        [MinLength(3, ErrorMessage = "The First Name field must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "The First Name field must be at most 50 characters long.")]

        public required string LastName;

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email")]
        [StringLength(50, ErrorMessage = "The Email field must be at most 50 characters long.", MinimumLength = 5)]
        public required string Email;

        [DataType(DataType.Password)]
        [MaxLength(50, ErrorMessage = "The Password field must be at most 50 characters long.")]
        [MinLength(6, ErrorMessage = "The Password field must be at least 6 characters long.")]
        [Required(ErrorMessage = "The Password field is required.")]
        public required string Password;
    }
}