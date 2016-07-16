using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Practice.Services.Interfaces;
using System.Collections.Generic;
using DbOps.DtoModels;
using System.Threading.Tasks;
using Practice.Web.Controllers;
using System.Net;
using System.Net.Http;

namespace Practice.Web.Tests
{
    [TestClass]
    public class ValuesControllerTest
    {
        private MockRepository _repository;
        private Mock<IAddEmployee> _addEmployeeMock;
        private Mock<IDeleteEmployee> _deleteEmployeeMock;
        private Mock<IUpdateEmployee> _updateEmployeeMock;
        private ValuesController valuesController;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new MockRepository(MockBehavior.Strict);
            _addEmployeeMock = _repository.Create<IAddEmployee>();
            _deleteEmployeeMock = _repository.Create<IDeleteEmployee>();
            valuesController = new ValuesController(_addEmployeeMock.Object, _deleteEmployeeMock.Object, _updateEmployeeMock.Object);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _repository.VerifyAll();
        }

        [TestMethod]
        public void AddEmployee_ValidInputReturnsHttpResponseMessageStatusOK()
        {
            //Arrange
            _addEmployeeMock.Setup(x => x.Add(It.IsAny<List<Employees>>()))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
            //Act
            var response = valuesController.AddEmployee(It.IsAny<List<Employees>>()).Result;
            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void AddEmployee_ValidInputReturnsCorrectHttpReasonPhrase()
        {
            //Arrange
            _addEmployeeMock.Setup(x => x.Add(It.IsAny<List<Employees>>()))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
            //Act
            var response = valuesController.AddEmployee(It.IsAny<List<Employees>>()).Result;
            //Assert
            Assert.IsTrue(response.ReasonPhrase == "Entry saved");
        }
    }
}
