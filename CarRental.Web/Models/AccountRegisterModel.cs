using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Web.Models
{
    public class AccountRegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CreditCard { get; set; }
        public string ExpDate { get; set; }
        public string LoginEmail { get; set; }
        public string Password { get; set; }
    }

    public class State
    {
        public string Abbrev { get; set; }
        public string Name { get; set; }
    }
}
