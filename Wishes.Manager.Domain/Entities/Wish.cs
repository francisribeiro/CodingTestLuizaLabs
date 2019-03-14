using CodingTestLuizaLabs.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CodingTestLuizaLabs.Model
{
    [Table("whishes")]
    public class Wish : BaseEntity
    {
        #region Properties

        [DataMember(Order = 2)]
        public long IdProduct { get; private set; }

        [DataMember(Order = 3)]
        public long IdUser { get; private set; }

        [ForeignKey("IdProduct")]
        public Product Product { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }

        #endregion

        #region Constructor

        public Wish(long IdProduct, long IdUser)
        {
            SetProductId(IdProduct);
            SetUserId(IdUser);
        }

        #endregion

        #region Methods

        public void SetProductId(long idProduct)
        {
            IdProduct = idProduct;
        }

        public void SetUserId(long idUser)
        {
            IdUser = idUser;
        }

        #endregion
    }
}
