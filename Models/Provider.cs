using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_Project.Models
{
    public class Provider
    {
        private String name;
        private String address;
        
        public Provider()
        {
            throw new NotImplementedException("Don't Use This Constructor | Bad Gateway");
        }

        public Provider(String name, String address)
        {
            this.name = name;
            this.address = address;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String newName)
        {
            name = newName;
        }

        public String getAddress()
        {
            return address;
        }

        public void setAddress(String newAddress)
        {
            address = newAddress;
        }
    }
}