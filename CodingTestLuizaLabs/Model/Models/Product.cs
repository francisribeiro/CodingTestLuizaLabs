using CodingTestLuizaLabs.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CodingTestLuizaLabs.Model
{
    [Table("products")]
    public class Product : BaseEntity
    {
        [DataMember(Order = 2)]
        public string Name { get; set; }
    }
}
