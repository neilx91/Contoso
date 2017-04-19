using System;
using System.ComponentModel.DataAnnotations;
using Contoso.Model.Common;

namespace Contoso.Model
{
    public class OfficeAssignment : AuditableEntity<int>
    {
        public OfficeAssignment()
        {
            CreatedDate = DateTime.Now;
        }
        public int InstructorId { get; set; }

        [MaxLength(150)]
        public string Location { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}