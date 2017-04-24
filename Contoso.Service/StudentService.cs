using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data.Repositories;
using Contoso.Model;
using Contoso.Model.Common;

namespace Contoso.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetAllStudents(int? page, int pageSize, out int totalCount)
        {
            var students = _studentRepository.GetPagedList(out totalCount, page, pageSize, null, null,
                new SortExpression<Student>(s => s.FirstName, ListSortDirection.Ascending));
            return students;
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public IEnumerable<Student> GetStudentByName(string name)
        {
            return _studentRepository.GetMany(s => s.LastName.Contains(name) || s.FirstName.Contains(name)).ToList();
        }

        public Student GetStudentByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        public void CreateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }

    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents(int? page, int pageSize, out int totalCount);
        Student GetStudentById(int id);
        IEnumerable<Student> GetStudentByName(string name);
        Student GetStudentByCode(string employeeCode);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
    }
}