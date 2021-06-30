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
        public static List<Provider> providers = new List<Provider>();

        private static String[] providerNames = { "Herndon VA","RTP North Carolina","San Jose California","Toronto Canada"};
        private static String[] addresses = {"21154 Sophie Dr. Herndon VA, 24211","9629 Athens Pl. North Carolina, 20878","123 Main St. San Jose California, 12345","456 Some Other Avenue Toronto Canada, 67890" };

        static ParentController()
        {
            for(int i = 0; i < providerNames.Length; i++)
            {
                providers.Add(new Provider(providerNames[i], addresses[i]));
            }
        }

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

        [HttpGet]
        [Route("api/Parent/GetProviders")]
        public IEnumerable<Provider> GetProviders()
        {
            return (IEnumerable < Provider > )providers;
        }
    }
}
