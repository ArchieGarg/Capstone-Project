using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Capstone_Project.Controllers
{
    public class DataController : ApiController
    {
        
        [HttpGet]
        [Route("api/Data/Do/{toDo}")]
        public HttpResponseMessage Do([FromUri] String toDo)
        {
            HttpResponseMessage resp = Request.CreateResponse();
            resp.Content = new StringContent("Your Get Query: " + toDo);
            return resp;
        }
    }
}
