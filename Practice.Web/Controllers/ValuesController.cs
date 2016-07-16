using DbOps;
using DbOps.DtoModels;
using Newtonsoft.Json;
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

        //public ValuesController() { }
        public ValuesController(IAddEmployee addEmployee, IDeleteEmployee deleteEmployee, IUpdateEmployee updateEmployee)
        {
            _addEmployee = addEmployee;
            _deleteEmployee = deleteEmployee;
            _updateEmployee = updateEmployee;
        }

        [HttpPost]
        [Route("employee/add")]
        public async Task<HttpResponseMessage> AddEmployee([FromBody] List<Employees> emp)
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
                    await _addEmployee.Add(emp);

                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        ReasonPhrase = HttpReasonPhrases.SuccessfulPost
                    };
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        ReasonPhrase = $"{HttpReasonPhrases.FailedPost}"
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
        public async Task<HttpResponseMessage> UpdateEmployee([FromUri]int id, [FromBody] Employees emp)
        {
            try
            {
               await _updateEmployee.Update(id, emp);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = $"{HttpReasonPhrases.FailedUpdate} {ex.ToString()}"
                };
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                ReasonPhrase = HttpReasonPhrases.SuccessfulUpdate
            };
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
