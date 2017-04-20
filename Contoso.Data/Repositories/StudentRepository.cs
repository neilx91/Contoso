using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Model;
using InterviewQuestionBank.Data;

namespace Contoso.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ContosoDbContext context) : base(context)
        {
        }
    }

    public interface IStudentRepository : IRepository<Student>
    {
    }
}