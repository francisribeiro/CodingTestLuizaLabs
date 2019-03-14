using CodingTestLuizaLabs.Common.Validation;
using CodingTestLuizaLabs.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CodingTestLuizaLabs.Model
{
    [Table("users")]
    public class User : BaseEntity
    {
        #region Properties

        public const int MaxLength = 250;
        public const int MinLength = 4;

        [DataMember(Order = 2)]
        public string Name { get; private set; }

        [DataMember(Order = 3)]
        public string Email { get; private set; }

        #endregion

        #region Constructor

        public User(string name, string email)
        {
            SetName(name);
            SetEmail(email);
        }

        #endregion

        #region Methods

        public void SetName(string name)
        {
            AssertionConcern.AssertArgumentNotEmpty(name, "Name is required");
            AssertionConcern.AssertArgumentLength(name, MinLength, MaxLength, string.Format("Name needs to be between {0} and {1} characters", MinLength, MaxLength));

            Name = name;
        }

        public void SetEmail(string email)
        {
            AssertionConcern.AssertArgumentNotEmpty(email, "Email is required");
            AssertionConcern.AssertArgumentLength(email, MinLength, MaxLength, string.Format("Email needs to be between {0} and {1} characters", MinLength, MaxLength));
            EmailAssertionConcern.AssertIsValid(email, "Email is invalid");

            Email = email;
        }

        #endregion
    }
}
