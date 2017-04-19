using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contoso.Model.Common;

namespace Contoso.Model
{
    public class Course : AuditableEntity<int>
    {
        public Course()
        {
            CreatedDate = DateTime.Now;
        }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}