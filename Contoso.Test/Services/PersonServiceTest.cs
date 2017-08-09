using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Contoso.Data.Repositories;
using Contoso.Model;
using Contoso.Service;
using Moq;

namespace Contoso.Test.Services
{
    [TestClass]
    public class PersonServiceTest
    {
        private Mock<IPersonRepository> _mockPersonRepository;
        private IPersonService _personService;
        private List<Person> _persons;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            _mockPersonRepository = new Mock<IPersonRepository>();
            _personService = new PersonService(_mockPersonRepository.Object);
            _persons = new List<Person>
            {
               // new Student {  }
                //new Person
                //{

                //}
                
            };
            //_mockPersonRepository.Setup(p => p.Get()).Returns((string s) => _persons.First(e => e.Email == s));
        }

        //[TestMethod]
        //public void Check_Person_ByUserName_FromTheFakeData()
        //{
        //    var person = _personService.GetPersonByUserName("emailaddress");
        //}
    }
}
