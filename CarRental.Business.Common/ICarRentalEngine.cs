using System;
using System.Collections.Generic;
using System.Linq;
using CarRental.Business.Entities;
using Core.Common.Contracts;

namespace CarRental.Business.Common
{
    public interface ICarRentalEngine : IBusinessEngine
    {
       // bool IsCarCurrentlyRented(int carId, int accountId);
       // bool IsCarCurrentlyRented(int carId);
        bool IsCarAvailableForRental(int carId, DateTime pickupDate, DateTime returnDate,
                                     IEnumerable<Rental> rentedCars, IEnumerable<Reservation> reservedCars);
       // Rental RentCarToCustomer(string loginEmail, int carId, DateTime rentalDate, DateTime dateDueBack);
    }
}
