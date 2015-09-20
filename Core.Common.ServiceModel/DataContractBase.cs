using System.Runtime.Serialization;

namespace Core.Common.ServiceModel
{
    [DataContract]
    public class DataContractBase : IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
