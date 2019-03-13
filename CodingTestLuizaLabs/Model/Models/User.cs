using CodingTestLuizaLabs.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CodingTestLuizaLabs.Model
{
    [Table("users")]
    public class User : BaseEntity
    {
        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        public string Email { get; set; }
    }
}
