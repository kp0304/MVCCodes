using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstProject.Models
{
    public class StudentClass
    {
        public StudentClass()
        {
            Students = new HashSet<Student>();
        }
        public int Id { get; set; }



        [Required]
        [MaxLength(50)]
        public string Name { get; set; }



        public virtual ICollection<Student> Students { get; set; }
    }
}