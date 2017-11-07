using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{

    public class UserData
    {
        public UserData(string firstname, string lastname, string address, string postcode, string city, string email, string phone, string pswd)
        {
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            Postcode = postcode;
            City = city;
            Email = email;
            Phone = phone;
            Pswd = pswd;

        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Pswd { get; set; }
    }
}
