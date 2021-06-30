using Capstone_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Capstone_Project.Controllers
{
    public class UserController : ParentController
    {
        [HttpPost]
        [Route("api/User/WaiverStatus")]
        public HttpResponseMessage WaiverStatus([FromBody] EmailWrapper username)
        {

            User user = getUser(username.email);

            HttpResponseMessage resp = Request.CreateResponse();
            resp.Content = new StringContent("Failure");

            if (user == null)
                return resp;
            resp.Content = new StringContent(user.getWaiverStatus().ToString());
            return resp;
        }

        [HttpPost]
        [Route("api/User/AddApptDateTime")]
        public HttpResponseMessage AddApptDateTime([FromBody] AppointmentWrapper payload)
        {
            User user = getUser(payload.email);

            HttpResponseMessage resp = Request.CreateResponse();
            resp.Content = new StringContent("Failure");

            if (user == null)
                return resp;
            user.setApptDateTime(payload.dateTime);
            resp.Content = new StringContent("Success");
            return resp;
        }

        [HttpPost]
        [Route("api/User/GetApptDateTime/")]
        public HttpResponseMessage GetApptDateTime([FromBody] EmailWrapper username)
        {
            User user = getUser(username.email);

            HttpResponseMessage resp = Request.CreateResponse();
            resp.Content = new StringContent("Failure");

            if (user == null)
                return resp;
            resp.Content = new StringContent(user.getApptDateTime());
            return resp;
        }

        [HttpPost]
        [Route("api/User/GetUsername/")]
        public HttpResponseMessage GetUsername([FromBody] EmailWrapper username)
        {
            User user = getUser(username.email);

            HttpResponseMessage resp = Request.CreateResponse();
            resp.Content = new StringContent("Failure");

            if (user == null)
                return resp;
            resp.Content = new StringContent(user.getName());
            return resp;
        }
    }
}