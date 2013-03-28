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
    }
}
