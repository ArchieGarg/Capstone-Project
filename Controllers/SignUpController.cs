using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Capstone_Project.Models;

namespace Capstone_Project.Controllers
{
    public class SignUpController : ParentController
    {

        [HttpPost]
        [Route("api/SignUp/SignUp")]
        public HttpResponseMessage SignUp(SignUpPayload payload)
        {
            String username = payload.name;
            String email = payload.email;
            String birthDate = payload.birthDate;
            String password = payload.password;

            Debug.WriteLine("Username: " + username + " Password: " + password + " Email: " + email + " BirthDate: " + birthDate);


            HttpResponseMessage resp = Request.CreateResponse();
            resp.Content = new StringContent("User With The Email Provided Already Exist!");

            User patient = getUser(email);
            if (patient != null)
            {
                resp.Headers.Add("location", "/signup.html");
                return resp;
            }

            users.Add(new User(username, email, birthDate, password));
            resp.Headers.Add("location", "/login.html");
            resp.Content = new StringContent("Account Successfully Created! You may now log in");
            return resp;
        }
    }
}
