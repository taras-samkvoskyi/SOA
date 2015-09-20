using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Common
{
    public class UnableToRentForDateException : ApplicationException
    {
        public UnableToRentForDateException(string message)
            : base(message)
        {
        }

        public UnableToRentForDateException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
