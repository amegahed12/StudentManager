using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManager.Models
{
    public class Department
    {

        [Key]
        public int DeptId { get; set; }



        [DisplayName("Department Name")]
        [Required(ErrorMessage = "The Department Name field is required.")]
        [MinLength(2, ErrorMessage = "The Department Name field must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "The Department Name field must be at most 50 characters long.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "The Department Name field must contain only letters, numbers, and spaces.")]
        public required string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}