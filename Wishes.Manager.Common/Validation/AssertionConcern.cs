using System;

namespace CodingTestLuizaLabs.Common.Validation
{
    public class AssertionConcern
    {
        /// <summary>
        /// Checks whether the size of the argument is within the range
        /// </summary>
        /// <param name="stringValue">Item to check</param>
        /// <param name="minimum">Minimum size allowed</param>
        /// <param name="maximum">Maximum size allowed</param>
        /// <param name="message">Message to the error</param>
        public static void AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            if (string.IsNullOrEmpty(stringValue))
                stringValue = string.Empty;

            var length = stringValue.Trim().Length;

            if (length < minimum || length > maximum)
                throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Checks if argument is not empty
        /// </summary>
        /// <param name="stringValue">Item to check</param>
        /// <param name="message">Message to the error</param>
        public static void AssertArgumentNotEmpty(string stringValue, string message)
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
                throw new InvalidOperationException(message);
        }
    }
}
