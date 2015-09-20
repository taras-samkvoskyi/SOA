using Core.Common.ServiceModel;
using System;
using System.Runtime.Serialization;

namespace CarRental.Business.Contracts
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
