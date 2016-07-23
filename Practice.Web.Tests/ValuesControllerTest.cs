using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Practice.Services.Interfaces;
using System.Collections.Generic;
using DbOps.DtoModels;
using System.Threading.Tasks;
using Practice.Web.Controllers;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Practice.Web.Interfaces;

namespace Practice.Web.Tests
{
    [TestClass]
    public class ValuesControllerTest
    {
        private MockRepository _repository;
        private Mock<IAddEmployee> _addEmployeeMock;
        private Mock<IDeleteEmployee> _deleteEmployeeMock;
        private Mock<IUpdateEmployee> _updateEmployeeMock;
        private Mock<IModelstateErrorLogger> _modelstateErrorLoggerMock;
        private Mock<ICookieValidator> _cookieValidatorMock;
        private ValuesController valuesController;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new MockRepository(MockBehavior.Strict);
            _addEmployeeMock = _repository.Create<IAddEmployee>();
            _deleteEmployeeMock = _repository.Create<IDeleteEmployee>();
            _updateEmployeeMock = _repository.Create<IUpdateEmployee>();
            _modelstateErrorLoggerMock = _repository.Create<IModelstateErrorLogger>();
            _cookieValidatorMock = _repository.Create<ICookieValidator>();
            valuesController = new ValuesController(_addEmployeeMock.Object, _deleteEmployeeMock.Object, _updateEmployeeMock.Object, _modelstateErrorLoggerMock.Object, _cookieValidatorMock.Object);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _repository.VerifyAll();
        }

        [TestMethod]
        public void AddEmployee_ValidInputReturnsCorrectHttpResponseMessageStatus()
        {
            //Arrange
            _addEmployeeMock.Setup(x => x.AddEmployees(It.IsAny<List<Employees>>()))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
            //Act
            var response = valuesController.AddEmployees(It.IsAny<List<Employees>>()).Result;
            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void AddEmployee_ValidInputReturnsCorrectHttpReasonPhrase()
        {
            //Arrange
            _addEmployeeMock.Setup(x => x.AddEmployees(It.IsAny<List<Employees>>()))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
            //Act
            var response = valuesController.AddEmployees(It.IsAny<List<Employees>>()).Result;
            //Assert
            Assert.IsTrue(response.ReasonPhrase == "Entry saved");
        }

        [TestMethod]
        public void AddEmployee_InvalidInputReturnsCorrectHttpResponseMessageStatus()
        {
            //Arrange
            var emp = new List<Employees>
            {
                new Employees
                {
                    Lastname = "Dalton"
                }
            };
            _modelstateErrorLoggerMock.Setup(x => x.ModelstateErrors(It.IsAny<ModelStateDictionary>()))
                .Returns("First name is required");
            //Act
            valuesController.Configuration = new HttpConfiguration();
            valuesController.Validate(emp);
            var response = valuesController.AddEmployees(emp).Result;

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void AddEmployee_InvalidInputReturnsCorrectHttpReasonPhrase()
        {
            //Arrange
            var emp = new List<Employees>
            {
                new Employees
                {
                    Lastname = "Dalton"
                }
            };

            _modelstateErrorLoggerMock.Setup(x => x.ModelstateErrors(It.IsAny<ModelStateDictionary>()))
                .Returns("First name is required. ");

            //Act
            valuesController.Configuration = new HttpConfiguration();
            valuesController.Validate(emp);
            var response = valuesController.AddEmployees(emp).Result;

            //Assert
            Assert.IsTrue(response.ReasonPhrase == "Entry not saved. First name is required. ");
        }

        [TestMethod]
        public void UpdateEmployee_ValidInputReturnsCorrectHttpReasonPhrase()
        {
            //Arrange
            var emp = new Employees
            {
                Firstname = "Kim",
                Lastname = "Dalton"
            };

            _updateEmployeeMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Employees>()))
                .Returns(Task.FromResult(new HttpResponseMessage { ReasonPhrase = "Employee updated" }));

            //Act
            valuesController.Configuration = new HttpConfiguration();
            valuesController.Validate(emp);
            var response = valuesController.UpdateEmployee(1, emp).Result;

            //Assert
            Assert.IsTrue(response.ReasonPhrase == "Employee updated");
        }

        [TestMethod]
        public void UpdateEmployee_InvalidInputReturnsCorrectHttpReasonPhrase()
        {
            //Arrange
            var emp = new Employees
            {
                Lastname = "Dalton"
            };


            _modelstateErrorLoggerMock.Setup(x => x.ModelstateErrors(It.IsAny<ModelStateDictionary>()))
                .Returns("First name is required. ");

            //Act
            valuesController.Configuration = new HttpConfiguration();
            valuesController.Validate(emp);
            var response = valuesController.UpdateEmployee(1, emp).Result;

            //Assert
            Assert.IsTrue(response.ReasonPhrase == "Employee update failed. First name is required. ");
        }
    }
}
