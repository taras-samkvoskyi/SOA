using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Web.Models
{
    public class AccountChangePasswordModel
    {
        public string LoginEmail { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
