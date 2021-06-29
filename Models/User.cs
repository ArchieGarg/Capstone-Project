using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_Project.Models
{
    public class User
    {
        private String name;
        private String email;
        private String birthDate;
        private String password;
        private Boolean isLoggedIn;
        private Boolean signedWaiver;
        private String provider;

        public User()
        {
            throw new NotImplementedException("Don't Use This Constructor | Bad Gateway");
        }

        public User(String name, String email, String birthDate, String password)
        {
            this.name = name;
            this.email = email;
            this.birthDate = birthDate;
            this.password = password;
            isLoggedIn = false;
            signedWaiver = false;
        }

        public void LogIn()
        {
            isLoggedIn = true;
        }

        public void LogOut()
        {
            isLoggedIn = false;
        }

        public Boolean IsLoggedIn()
        {
            return isLoggedIn;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String newName)
        {
            name = newName;
        }

        public String getEmail()
        {
            return email;
        }

        public void setEmail(String newEmail)
        {
            email = newEmail;
        }

        public String getBirthDate()
        {
            return birthDate;
        }

        public String getPassword()
        {
            return password;
        }

        public void setPassword(String newPassword)
        {
            password = newPassword;
        }

        public void signWaiver()
        {
            signedWaiver = true;
        }

        public Boolean getWaiverStatus()
        {
            return signedWaiver;
        }

        public void setProvider(String newProvider)
        {
            provider = newProvider;
        }

        public String getProvider()
        {
            return provider;
        }
    }
}