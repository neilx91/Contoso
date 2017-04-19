using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contoso.Model
{
    [Table("Instructor")]
    public class Instructor : Person
    {
        public Instructor()
        {
            CreatedDate = DateTime.Now;
        }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        public  ICollection<Course> Courses { get; set; }
        public  OfficeAssignment OfficeAssignment { get; set; }
    }
}