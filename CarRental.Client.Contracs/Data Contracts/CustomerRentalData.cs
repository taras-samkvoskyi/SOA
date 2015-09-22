using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Core.Common.ServiceModel;

namespace CarRental.Client.Contracts
{
    [DataContract]
    public class CustomerRentalData : DataContractBase
    {
        [DataMember]
        public int RentalId { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string Car { get; set; }

        [DataMember]
        public DateTime DateRented { get; set; }

        [DataMember]
        public DateTime ExpectedReturn { get; set; }
    }
}
