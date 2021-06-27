using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_Project.Models
{
    public class Patient:User
    {
        private LinkedList<Provider> myProviders = new LinkedList<Provider>();
    }
}