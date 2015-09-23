using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Web.Models
{
    public class AccountLoginModel
    {
        public string LoginEmail { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}