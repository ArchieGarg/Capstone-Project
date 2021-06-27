using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;
using Capstone_Project.Models;

namespace Capstone_Project.Controllers
{
    public class LoginController : ParentController
    {

        [HttpPost]
        [Route("api/Login/Login")]
        public HttpResponseMessage Login([FromBody] LoginPayload payload)
        {
            String username = payload.username;
            String password = payload.password;

            Debug.WriteLine("Username: " + username + " Password: " + password);
            User patient = getUser(username);

            HttpResponseMessage resp = Request.CreateResponse();

            if (patient == null)
            {
                resp.Headers.Add("Location", "/Login.html");
                resp.Content = new StringContent("Unauthorized Login");
            }
            else
            {
                if (patient.getEmail().Equals(username) && patient.getPassword().Equals(password))
                {
                    patient.LogIn();
                    resp.Content = new StringContent("Success! You are now logged in");
                    resp.Headers.Add("Location", "/Patient.html");
                }
                else
                {
                    resp.Content = new StringContent("Unauthorized Login");
                    resp.Headers.Add("Location", "/Login.html");
                }
            }

            return resp;
        }

        [HttpGet]
        [Route("api/Login/CanAccess")]
        public HttpResponseMessage CanAccess([FromBody] String username)
        {
            Debug.WriteLine("Username: " + username);
            User patient = getUser(username);

            HttpResponseMessage resp = Request.CreateResponse();
            resp.Headers.Add("Location", "/Login.html");

            if (patient == null)
            {
                resp.Content = new StringContent("Unauthorized Access");
            }
            else
            {
                resp.Content = new StringContent("Unauthorized Access");
                if (patient.getEmail().Equals(username) && patient.IsLoggedIn())
                {
                    resp.Content = new StringContent("Authorized Access");
                    resp.Headers.Add("Location", "/Patient.html");
                }
            }
            return resp;
        }

        [HttpPost]
        [Route("api/Login/LogOut")]
        public HttpResponseMessage LogOut([FromBody] String username)
        {
            Debug.WriteLine("Username: " + username);
            User patient = getUser(username);

            HttpResponseMessage resp = Request.CreateResponse();
            resp.Headers.Add("Location", "/Login.html");

            if (patient == null)
            {
                resp.Content = new StringContent("Unauthorized Logout");
            }
            else
            {
                resp.Content = new StringContent("Unauthorized Logout");
                if (patient.getEmail().Equals(username))
                {
                    patient.LogOut();
                    resp.Content = new StringContent("Success! You are now logged out");
                    resp.Headers.Add("Location", "/Patient.html");
                }
            }
            return resp;
        }
    }
}
