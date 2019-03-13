using CodingTestLuizaLabs.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CodingTestLuizaLabs.Model
{
    [Table("whishes")]
    public class Wish : BaseEntity
    {
        [DataMember(Order = 2)]
        public long IdProduct { get; set; }

        [DataMember(Order = 3)]
        public long IdUser { get; set; }

        [ForeignKey("IdProduct")]
        public Product Product { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}
