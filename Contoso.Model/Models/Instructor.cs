using System;
using System.Collections.Generic;
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

        public DateTime HireDate { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}