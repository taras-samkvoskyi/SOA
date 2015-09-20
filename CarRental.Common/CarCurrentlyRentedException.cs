using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Common
{
    public class CarCurrentlyRentedException : ApplicationException
    {
        public CarCurrentlyRentedException(string message)
            : base(message)
        {
        }

        public CarCurrentlyRentedException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
