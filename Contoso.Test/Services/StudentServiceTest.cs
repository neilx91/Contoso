using System.Collections.Generic;
using System.Linq;
using Contoso.Data.Repositories;
using Contoso.Model;
using Contoso.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Contoso.Test.Services
{
    [TestClass]
    public class StudentServiceTest
    {
        private Mock<IPersonRepository> _mockPersonRepository;
        private Mock<IStudentRepository> _mockStudentRepository;
        private IStudentService _studentService;
        private List<Student> students;

        [TestMethod]
        public void Check_StudentsCountFromTheFakeData()
        {
            _mockStudentRepository.Setup(s => s.GetAll()).Returns(students);
        }

        [TestMethod]
        public void Check_Student_ById_FromTheFakeData()
        {
            var student = _studentService.GetStudentById(2);
            Assert.IsNotNull(student); // Test if student is null or not
            Assert.IsInstanceOfType(student, typeof(Student));
            Assert.AreEqual("Test LastName2", student.LastName);
        }

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            _mockStudentRepository = new Mock<IStudentRepository>();
            _mockPersonRepository = new Mock<IPersonRepository>();
            _studentService = new StudentService(_mockPersonRepository.Object, _mockStudentRepository.Object);

            students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "Test Name 1",
                    LastName = "Test LastName1",
                    Age = 23,
                    City = "DC",
                    Email = "test@test.com"
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Test Name 2",
                    LastName = "Test LastName2",
                    Age = 23,
                    City = "DC",
                    Email = "test@test.com"
                },
                new Student
                {
                    Id = 1,
                    FirstName = "Test Name 1",
                    LastName = "Test LastName1",
                    Age = 23,
                    City = "DC",
                    Email = "test@test.com"
                },
                new Student
                {
                    Id = 1,
                    FirstName = "Test Name 1",
                    LastName = "Test LastName1",
                    Age = 23,
                    City = "DC",
                    Email = "test@test.com"
                },
                new Student
                {
                    Id = 1,
                    FirstName = "Test Name 1",
                    LastName = "Test LastName1",
                    Age = 23,
                    City = "DC",
                    Email = "test@test.com"
                },
                new Student
                {
                    Id = 1,
                    FirstName = "Test Name 1",
                    LastName = "Test LastName1",
                    Age = 23,
                    City = "DC",
                    Email = "test@test.com"
                },
                new Student
                {
                    Id = 1,
                    FirstName = "Test Name 1",
                    LastName = "Test LastName1",
                    Age = 23,
                    City = "DC",
                    Email = "test@test.com"
                },
                new Student
                {
                    Id = 1,
                    FirstName = "Test Name 1",
                    LastName = "Test LastName1",
                    Age = 23,
                    City = "DC",
                    Email = "test@test.com"
                }
            };

            _mockStudentRepository.Setup(s => s.GetById(It.IsAny<int>()))
                .Returns((int s) => students.First(x => x.Id == s));
            _mockStudentRepository.Setup(s => s.GetStudentByLastName(It.IsAny<string>()))
                .Returns((string s) => students.First(x => x.LastName == s));
        }
    }
}