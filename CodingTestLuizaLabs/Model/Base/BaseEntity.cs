using System.Runtime.Serialization;

namespace CodingTestLuizaLabs.Model.Base
{
    [DataContract]
    public class BaseEntity
    {
        [DataMember(Order = 1)]
        public long? Id { get; set; }
    }
}
