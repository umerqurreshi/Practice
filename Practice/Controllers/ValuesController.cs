using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practice.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private Repo _repo = new Repo();
        // GET api/values
        [Route("employees/emp")]
        public HttpResponseMessage Get()
        {
            try
            {
                _repo.Add();
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = ex.ToString()
                };
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
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
