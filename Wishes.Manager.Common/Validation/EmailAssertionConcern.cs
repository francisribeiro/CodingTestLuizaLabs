using System;
using System.Text.RegularExpressions;

namespace CodingTestLuizaLabs.Common.Validation
{
    public class EmailAssertionConcern
    {
        /// <summary>
        /// Validate an email
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="message">Message to the error</param>
        public static void AssertIsValid(string email, string message)
        {
            if (!Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                throw new InvalidOperationException(message);
        }
    }
}
