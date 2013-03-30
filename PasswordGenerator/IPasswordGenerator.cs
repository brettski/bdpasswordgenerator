using System;
namespace Brettski.PasswordGenerator
{
    interface IPasswordGenerator
    {
        /// <summary>
        /// Generates a password
        /// </summary>
        /// <returns>A random password</returns>
        string GeneratePassword();
        /// <summary>
        /// Generates a password with given length
        /// </summary>
        /// <param name="Length">Length of password to create</param>
        /// <returns></returns>
        string GeneratePassword(int Length);
        /// <summary>
        /// Set or get values used as upper case alpha values.
        /// Default: ABCDEFGHIJKLMNOPQRSTUVWXYZ
        /// Max length: 256
        /// </summary>
        string UpperAlpha { get; set; }
        /// <summary>
        /// Set or get values used as lower case alpha values.
        /// Default: abcdefghijklmnopqrstuvwxyz
        /// Max length: 256
        /// </summary>
        string LowerAlpha { get; set; }
        /// <summary>
        /// Set or get values used as number values.
        /// Default: 0123456789
        /// Max length: 256
        /// </summary>
        string Numbers { get; set; }
        /// <summary>
        /// Set or get values used as punctuation values.
        /// Default: !.?:;(){}[]
        /// Max length: 256
        /// </summary>
        string Punctuation { get; set; }
        /// <summary>
        /// Set or get values used as special values.
        /// Default: ~@#$%^&*_-+=|\/';:<>,"
        /// Max length: 256
        /// </summary>
        string Special { get; set; }
        /// <summary>
        /// Length of password to generate.
        /// </summary>
        int PasswordLength { get; set; }
        /// <summary>
        /// Not Enabled
        /// </summary>
        string PasswordPhonetic { get; }
        /// <summary>
        /// Last password generated
        /// </summary>
        string PasswordResult { get; }
        /// <summary>
        /// Set true to use upper case value set
        /// </summary>
        bool UseUpper { get; set; }
        /// <summary>
        /// Set true to use lower case value set
        /// </summary>
        bool UseLower { get; set; }
        /// <summary>
        /// Set true to use number value set
        /// </summary>
        bool UseNumbers { get; set; }
        /// <summary>
        /// Set true to use punctuation value set
        /// </summary>
        bool UsePunctuation { get; set; }
        /// <summary>
        /// Set true to use special value set
        /// </summary>
        bool UseSpecial { get; set; }
    }
}
