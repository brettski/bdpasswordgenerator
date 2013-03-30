using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brettski.PasswordGenerator
{
    /// <summary>
    /// Defines a password character type used in generated password
    /// </summary>
    class PasswordCharacterType
    {
        public PasswordCharacterType(string Name, string CharacterString)
        {
            this.TypeName = Name;
            this.CharacterString = CharacterString;
        }

        public string TypeName { get; set; }
        public string CharacterString { get; set; }
        public int length
        {
            get { return CharacterString.Length; }
        }
    }
}
