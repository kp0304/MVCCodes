using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practice1.Models
{
    public class Student: IValidatableObject
    {
        [Display(Name="Student Id")]
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Range(1, 2, ErrorMessage = "Please Select Gender")]
        public Gender Gender { get; set; }
        

        public bool Compare(Student student)
        {
            if (this.StudentId == student.StudentId)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(DateOfBirth >= DateTime.Now)
            {
                yield return new ValidationResult("Date of birth cannot be in future", new[] { nameof(DateOfBirth) });
            }
        }
    }

    public enum Gender
    {
        Male=1,
        Female
    }
}