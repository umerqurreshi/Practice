using DbOps.DtoModels;
using Practice.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Practice.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IAddEmployee _addEmployee;
        private readonly IDeleteEmployee _deleteEmployee;
        private readonly IUpdateEmployee _updateEmployee;
        private readonly IModelstateErrorLogger _modelstateErrorLogger;

        //public ValuesController() { }
        public ValuesController(IAddEmployee addEmployee, IDeleteEmployee deleteEmployee, IUpdateEmployee updateEmployee, IModelstateErrorLogger modelstateLoggerError)
        {
            _addEmployee = addEmployee;
            _deleteEmployee = deleteEmployee;
            _updateEmployee = updateEmployee;
            _modelstateErrorLogger = modelstateLoggerError;
        }

        [HttpPost]
        [Route("employees/add")]
        public async Task<HttpResponseMessage> AddEmployees(List<Employees> emp)
        {
            //Use below commented out code when checking if returned obj is what you expect

            /*var content = Request.Content.ReadAsStringAsync().Result;
            
            var employeeObjCheck = JsonConvert.DeserializeObject<Employees>(content);

            if (employeeObjCheck == null)
            {
                retVal = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = HttpReasonPhrases.FailedPost
                };

                return retVal;
            }*/

            if (ModelState.IsValid)
            {
                await _addEmployee.AddEmployees(emp);

                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = HttpReasonPhrases.SuccessfulPost
                };
            }
            else
            {
                string modelstateErrors = _modelstateErrorLogger.ModelstateErrors(ModelState);

                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = $"{HttpReasonPhrases.FailedPost}. {modelstateErrors}"
                };

            }
        }

        [HttpPost]
        [Route("employee/add")]
        public async Task<HttpResponseMessage> AddEmployee(Employees emp)
        {
            //Use below commented out code when checking if returned obj is what you expect

            /*var content = Request.Content.ReadAsStringAsync().Result;
            
            var employeeObjCheck = JsonConvert.DeserializeObject<Employees>(content);

            if (employeeObjCheck == null)
            {
                retVal = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = HttpReasonPhrases.FailedPost
                };

                return retVal;
            }*/

            if (ModelState.IsValid)
            {
                await _addEmployee.AddSingleEmployee(emp);

                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = HttpReasonPhrases.SuccessfulPost
                };
            }
            else
            {
                string modelstateErrors = _modelstateErrorLogger.ModelstateErrors(ModelState);

                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = $"{HttpReasonPhrases.FailedPost}. {modelstateErrors}"
                };

            }
        }

        // GET api/values
        [HttpPost]
        [Route("employee/remove")]
        public async Task<HttpResponseMessage> DeleteEmployee([FromBody] int id)
        {
            try
            {
                await _deleteEmployee.Delete(id);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = $"{HttpReasonPhrases.FailedDelete} {ex.ToString()}"
                };
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                ReasonPhrase = HttpReasonPhrases.SuccessfulDelete
            };
        }

        [HttpPost]
        [Route("employee/update/{id}")]
        public async Task<HttpResponseMessage> UpdateEmployee([FromUri]int id, Employees emp)
        {
            if (ModelState.IsValid)
            {
                await _updateEmployee.Update(id, emp);

                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = $"{HttpReasonPhrases.SuccessfulUpdate}"
                };
            }
            else
            {
                string modelstateErrors = _modelstateErrorLogger.ModelstateErrors(ModelState);

                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = $"{HttpReasonPhrases.FailedUpdate}. {modelstateErrors}"
                };
            }
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
