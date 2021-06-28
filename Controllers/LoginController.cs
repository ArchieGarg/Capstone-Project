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

        [HttpPost]
        [Route("api/Login/CanAccess")]
        public HttpResponseMessage CanAccess([FromBody]EmailWrapper username)
        {
            Debug.WriteLine("Username: " + username.email);
            User patient = getUser(username.email);
            Debug.WriteLine(username.email);

            HttpResponseMessage resp = Request.CreateResponse();

            if (patient == null)
            {
                Debug.WriteLine("Where is this guy so cannot proccede!");
                resp.Headers.Add("Location", "/Login.html");
                resp.Content = new StringContent("Unauthorized Access");
            }
            else
            {
                resp.Content = new StringContent("Unauthorized Access");
                if (patient.getEmail().Equals(username.email) && patient.IsLoggedIn())
                {
                    Debug.WriteLine("Good to Go!");
                    resp.Content = new StringContent("Authorized Access");
                    resp.Headers.Add("Location", "/Patient.html");
                }
                else
                {
                    Debug.WriteLine("Not logged in and so cannot proccede!");
                    resp.Content = new StringContent("Unauthorized Access");
                    resp.Headers.Add("Location", "/Login.html");
                }
            }
            return resp;
        }

        [HttpPost]
        [Route("api/Login/LogOut")]
        public HttpResponseMessage LogOut([FromBody] EmailWrapper username)
        {
            Debug.WriteLine("Username: " + username.email);
            User patient = getUser(username.email);

            HttpResponseMessage resp = Request.CreateResponse();

            if (patient == null)
            {
                resp.Headers.Add("Location", "/Patient.html");
                resp.Content = new StringContent("Unauthorized Logout");
            }
            else
            {
                
                if (patient.getEmail().Equals(username.email))
                {
                    patient.LogOut();
                    resp.Content = new StringContent("Success! You are now logged out");
                    resp.Headers.Add("Location", "/Login.html");
                }
                else
                {
                    resp.Headers.Add("Location", "/Patient.html");
                    resp.Content = new StringContent("Unauthorized Logout");
                }
            }
            return resp;
        }
    }
}
