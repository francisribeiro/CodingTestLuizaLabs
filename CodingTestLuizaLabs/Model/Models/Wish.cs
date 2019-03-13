using CodingTestLuizaLabs.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingTestLuizaLabs.Model
{
    [Table("whishes")]
    public class Wish : BaseEntity
    {
        public long ProductId { get; set; }
        public long UserId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
