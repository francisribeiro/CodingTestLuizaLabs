using CodingTestLuizaLabs.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingTestLuizaLabs.Model
{
    [Table("products")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
    }
}
