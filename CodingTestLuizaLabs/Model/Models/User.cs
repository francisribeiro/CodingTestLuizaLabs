using CodingTestLuizaLabs.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingTestLuizaLabs.Model
{
    [Table("users")]
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
