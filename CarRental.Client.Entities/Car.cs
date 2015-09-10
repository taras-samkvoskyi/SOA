using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime;
using System.Reflection;
using Core.Common.Core;
using FluentValidation;

namespace CarRental.Client.Entities
{
    public class Car : ObjectBase
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
            set
            {
                if (_CarId != value)
                {
                    _CarId = value;
                    OnPropertyChanged(() => CarId);
                }
            }
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

        class CarValidator : AbstractValidator<Car>
        {
            public CarValidator()
            {
                RuleFor(obj => obj.Description).NotEmpty();
                RuleFor(obj => obj.Color).NotEmpty();
                RuleFor(obj => obj.RentalPrice).GreaterThan(0);
                RuleFor(obj => obj.Year).GreaterThan(2000).LessThanOrEqualTo(DateTime.Now.Year);
            }
        }

        protected override IValidator GetValidator()
        {
            return new CarValidator();
        }
    }

   
}
