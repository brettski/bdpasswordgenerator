using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brettski.PasswordGenerator
{
    /// <summary>
    /// Static thread safe general utilities
    /// </summary>
    static class Utilities
    {
        /// <summary>
        /// Return an empty string if the value is empty
        /// </summary>
        /// <param name="Value">Parameter tested for null</param>
        /// <returns>Value unless value is null, then empty string</returns>
        public static string IfNullReturnEmpty(string Value)
        {
            if (null == Value)
                return string.Empty;
            else
                return Value;
        }
        /// <summary>
        /// Verifies Character Values being passed in are valid
        /// </summary>
        /// <param name="Value">The character value being set</param>
        /// <param name="ParameterName">The class.parameter being updated. (E.g. PasswordGenerator.UpperAlpha)</param>
        /// <returns></returns>
        public static bool PassCharacterValueParameterChecks(string Value, string ParameterName )
        {
            bool retVal = false;
            if (null == Value)
                throw new NullReferenceException(ParameterName + "Must be set to a value");
            else if (Value.Length > 256)
                throw new ArgumentOutOfRangeException("PasswordGenerator.Numbers", "Value length must be less than or equal to 256");
            else
                retVal = true;
            return retVal;
        }
        /// <summary>
        /// verifies integer values being passed in are valid
        /// </summary>
        /// <param name="Value">Integer value</param>
        /// <param name="ParameterName">The class.parameter being updated. (E.g. PasswordGenerator.PasswordLength)</param>
        /// <returns></returns>
        public static bool IsPositiveInteger(int Value, string ParameterName)
        {
            if (Value < 1)
                throw new ArgumentException(string.Format("Value for {0} must be a postive integer greater than 0. (sent:{1})", ParameterName, Value), ParameterName);
            else
                return !(Value < 1);
        }
    }
}
