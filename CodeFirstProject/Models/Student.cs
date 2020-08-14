using System;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstProject.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-dd-MM}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Range(1, 3, ErrorMessage = "Please Select Gender")]
        public Gender Gender { get; set; }
        [Required]
        //  [ForeignKey(nameof(Class))]
        public int ClassId { get; set; }
        public virtual StudentClass Class { get; set; }
    }
}