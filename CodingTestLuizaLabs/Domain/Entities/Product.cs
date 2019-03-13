using CodingTestLuizaLabs.Common.Validation;
using CodingTestLuizaLabs.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CodingTestLuizaLabs.Model
{
    [Table("products")]
    public class Product : BaseEntity
    {
        #region Properties

        public const int MaxLength = 250;
        public const int MinLength = 20;

        [DataMember(Order = 2)]
        public string Name { get; private set; }

        #endregion

        #region Constructor

        public Product(string name)
        {
            SetName(name);
        }

        #endregion

        #region Methods

        public void SetName(string name)
        {
            AssertionConcern.AssertArgumentNotEmpty(name, "Name is required");
            AssertionConcern.AssertArgumentLength(name, MinLength, MaxLength, string.Format("Name needs to be between {0} and {1} characters", MinLength, MaxLength));

            Name = name;
        }

        #endregion
    }
}
