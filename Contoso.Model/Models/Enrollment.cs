using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Model.Common;


namespace Contoso.Model
{
    public class Enrollment: AuditableEntity<int>
    {
        public Enrollment()
        {
            CreatedDate = DateTime.Now;
        }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }

    public enum Grade
    {
        A,
        B,
        C,
        D,
        F
    }
}