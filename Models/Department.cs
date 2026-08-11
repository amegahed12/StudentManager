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
        public required string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}