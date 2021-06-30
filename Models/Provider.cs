using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_Project.Models
{
    public class Provider
    {
        public String name { get; private set; }
        public String address { get; private set; }
        public String[] apptTimes { get; private set; }
        
        public Provider()
        {
            throw new NotImplementedException("Don't Use This Constructor | Bad Gateway");
        }

        public Provider(String name, String address)
        {
            this.name = name;
            this.address = address;
            apptTimes = new string[] { "June 30th, 1:00pm EST", "June 30th, 5:00pm EST", "July 1st, 1:00pm EST", "July 1st, 5:00pm EST" };
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

        /*public override bool Equals(object obj)
        {
            Provider other = (Provider)obj;

            Boolean apptDateTimesEqual = true;

            int end = apptTimes.Length;
            if (end > other.apptTimes.Length)
                end = other.apptTimes.Length;
            for (int i = 0; i < end; i++)
                if (!apptTimes[i].Equals(other.apptTimes[i]))
                    apptDateTimesEqual = false;
            return other.name.Equals(other.name) && other.address.Equals(other.address) && apptDateTimesEqual;
        }*/

        public override string ToString()
        {
            return "Name" + name + " Address " + address;
        }
    }
}