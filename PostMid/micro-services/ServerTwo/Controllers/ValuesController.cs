using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerTwo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public object Get()
        {
            using (HttpClient client = new HttpClient()) 
            {
                var result = client.GetAsync("http://localhost:56666/api/City").Result;
                return result;
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
