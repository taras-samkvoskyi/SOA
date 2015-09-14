using System;
using System.Collections.Generic;
using System.Linq;
using CarRental.Business.Entities;

namespace CarRental.Data.Contracts
{
    public class CustomerRentalInfo
    {
        public Account Customer { get; set; }
        public Car Car { get; set; }
        public Rental Rental { get; set; }
    }
}