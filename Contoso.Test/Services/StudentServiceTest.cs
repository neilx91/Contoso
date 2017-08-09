using System.Collections.Generic;
using System.Linq;
using Contoso.Data.Repositories;
using Contoso.Model;
using Contoso.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Contoso.Model.Common;
using System.ComponentModel;

namespace Contoso.Test.Services
{
    [TestClass]
    public class StudentServiceTest
    {
        private Mock<IPersonRepository> _mockPersonRepository;
        private Mock<IStudentRepository> _mockStudentRepository;
        private IStudentService _studentService;
        private List<Student> _students;


        [TestMethod]
        public void Check_Student_ById_FromTheFakeData()
        {
            var student = _studentService.GetStudentById(2);
            Assert.IsNotNull(student); // Test if student is null or not
            Assert.IsInstanceOfType(student, typeof(Student)); //  Test if type returned is Student
            Assert.AreEqual("FTest LastName2", student.LastName); // Test if last name return is the same as expected
        }


        //Test normal conditions, then unexpected conditions: bad input/boundary conditions, then regression test to generate the bug you find
        [TestMethod]
        public void Check_StudentsCountFromTheFakeData()
        {
            //act
            int totalCount=0;
            var students = _studentService.GetAllStudents(1, 10, out totalCount);
            //assert
            Assert.IsInstanceOfType(students, typeof(IEnumerable<Student>)); //Test if type returned is List of Student or not         
            Assert.IsNotNull(students); //Test if Students are null or not
            //Assert.AreEqual(10, totalCount);
            Assert.AreEqual(10, students.Count()); //Test if the number of students returned are correct.
        }

        [TestMethod]
        public void Check_StudentsCount_WithDifferentPageSize_FromTheFakeData()
        {
            int totalCount = 0;
            var students = _studentService.GetAllStudents(3, 3, out totalCount);
            Assert.AreEqual(3, students.Count()); //Test if the number of students returned are correct.
        }

        [TestMethod]
        public void Check_Student_NotExisted_FromTheFakeData()
        {
            int totalCount = 0;
            var students = _studentService.GetAllStudents(5,10, out totalCount);
            Assert.AreEqual(0, students.Count()); //Test if the number of students returned is 0
        }

        

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException),"Student doesn't exist.")]
        public void Check_Student_ByNotExistingID_FromTheFakeData()
        {
            _studentService.GetStudentById(20);
            //Assert.IsNull(studentNotExisted); //Test if the student doesn't exist
        }

        [TestMethod]
        public void Check_Student_ByName_FromTheFakeData()
        {
            var students = _studentService.GetStudentByName("FTest");
            Assert.IsNotNull(students);
            Assert.IsInstanceOfType(students, typeof(IEnumerable<Student>));
            //Check if the firstname or lastname contains "FTest"
            foreach(var student in students)
            {
                //how to compare?
                FullNameCompare.ContainName("FTest", student.FullName);
            }
        }

        [TestMethod]
        public void Check_Student_ByName_NotExisted_FromTheFakeData()
        {
            var students = _studentService.GetStudentByName("Name");
            Assert.AreEqual(0, students.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Object reference not set to an instance of an object.")]
        public void Check_Student_ByNUllName_FromTheFakeData()
        {
            _studentService.GetStudentByName(null);
        }



        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            _mockStudentRepository = new Mock<IStudentRepository>();
            _mockPersonRepository = new Mock<IPersonRepository>();
            _studentService = new StudentService(_mockPersonRepository.Object, _mockStudentRepository.Object);

            _students = new List<Student>
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
                    LastName = "FTest LastName2",
                    Age = 33,
                    City = "DC",
                    Email = "test2@test.com"
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Test Name 3",
                    LastName = "Test LastName3",
                    Age = 43,
                    City = "DC",
                    Email = "test3@test.com"
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Test Name 4",
                    LastName = "FTest LastName4",
                    Age = 44,
                    City = "DC",
                    Email = "test4@test.com"
                },
                new Student
                {
                    Id = 5,
                    FirstName = "Test Name 5",
                    LastName = "Test LastName5",
                    Age = 25,
                    City = "DC",
                    Email = "test5@test.com"
                },
                new Student
                {
                    Id = 6,
                    FirstName = "FTest Name 6",
                    LastName = "Test LastName6",
                    Age = 26,
                    City = "DC",
                    Email = "test6@test.com"
                },
                new Student
                {
                    Id = 7,
                    FirstName = "Test Name 7",
                    LastName = "Test LastName7",
                    Age = 23,
                    City = "DC",
                    Email = "test7@test.com"
                },
                new Student
                {
                    Id = 8,
                    FirstName = "FTest Name 8",
                    LastName = "Test LastName8",
                    Age = 23,
                    City = "DC",
                    Email = "test8@test.com"
                },
                new Student
                {
                    Id = 9,
                    FirstName = "Test Name 9",
                    LastName = "Test LastName9",
                    Age = 33,
                    City = "DC",
                    Email = "test9@test.com"
                },
                new Student
                {
                    Id = 10,
                    FirstName = "Test Name 10",
                    LastName = "Test LastName10",
                    Age = 20,
                    City = "DC",
                    Email = "test10@test.com"
                }
            };

            //_mockStudentRepository.Setup(s => s.GetAll()).Returns(_students);

            _mockStudentRepository.Setup(s => s.GetById(It.IsAny<int>()))
                .Returns((int s) => _students.First(x => x.Id == s));

            _mockStudentRepository.Setup(s => s.GetStudentByLastName(It.IsAny<string>()))
                .Returns((string s) => _students.First(x => x.LastName == s));

            _mockStudentRepository.Setup(s => s.GetMany(x => x.FullName.Contains(It.IsAny<string>())))
                .Returns((string s) => _students.Where(x => x.FullName.Contains(s.ToString())));

            int totalCount = 0;
            var sort = new SortExpression<Student>(x => x.FirstName, ListSortDirection.Ascending);
            _mockStudentRepository.Setup(s => s.GetPagedList(out totalCount, It.IsAny<int?>(), It.IsAny<int?>(), null, null, It.IsAny<SortExpression<Student>>())).Returns(_students);
  
        }
    }
}