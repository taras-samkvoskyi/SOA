using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime;
using System.Reflection;


namespace CarRental.Client.Entities
{
    public class Car
    {
        int _CarId;
        string _Description;
        string _Color;
        int _Year;
        decimal _RentalPrice;
        bool _CurrentlyRented;

        public int CarId
        {
            get { return _CarId; }
            set { _CarId = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        public decimal RentalPrice
        {
            get { return _RentalPrice; }
            set { _RentalPrice = value; }
        }

        public bool CurrentlyRented
        {
            get { return _CurrentlyRented; }
            set { _CurrentlyRented = value; }
        }
    }
}
