using Capstone_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Capstone_Project.Controllers
{
    public class ParentController : ApiController
    {
        public static List<User> users = new List<User>();

        public User getUser(String username)
        {
            foreach(User user in users)
            {
                if (user.getEmail().Equals(username))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
