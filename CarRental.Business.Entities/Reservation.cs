using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Entities
{
    public class Reservation : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        private int _ReservationId;
        private int _AccountId;
        private int _CarId;
        private DateTime _ReturnDate;
        private DateTime _RentalDate;

        public int ReservationId
        {
            get { return _ReservationId; }
            set
            {
                if (_ReservationId != value)
                {
                    _ReservationId = value;                    
                }
            }
        }

        public int AccountId
        {
            get { return _AccountId; }
            set
            {
                if (_AccountId != value)
                {
                    _AccountId = value;
                }
            }
        }

        public int CarId
        {
            get { return _CarId; }
            set
            {
                if (_CarId != value)
                {
                    _CarId = value;
                }
            }
        }

        public DateTime ReturnDate
        {
            get { return _ReturnDate; }
            set
            {
                if (_ReturnDate != value)
                {
                    _ReturnDate = value;
                }
            }
        }

        public DateTime RentalDate
        {
            get { return _RentalDate; }
            set
            {
                if (_RentalDate != value)
                {
                    _RentalDate = value;
                }
            }
        }

        public int EntityId
        {
            get
            {
                return ReservationId;
            }

            set
            {
                ReservationId = value;
            }
        }

        public int OwnerAccountId
        {
            get
            {
                return AccountId;
            }
        }
    }
}
