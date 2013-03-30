using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Brettski.PasswordGenerator
{
    public class PasswordGenerator : IPasswordGenerator
    {

        public PasswordGenerator()
        {
            UpperAlpha = UPPER_ALPHA;
            LowerAlpha = LOWER_ALPHA;
            Numbers = NUMBERS;
            Punctuation = PUNCTUATION;
            Special = SPECIAL;
            PasswordLength = DEFAULT_PASSWORD_LENGTH;
            UseUpper = true;
            UseLower = true;
            UseNumbers = true;
            UsePunctuation = false;
            UseSpecial = false;
        }

        #region Methods

        public string GeneratePassword()
        {
            StringBuilder BuildingPw = new StringBuilder(PasswordLength);
            List<PasswordCharacterType> passwordCharTypeList = GetPasswordCharacterTypeList();

            for (int i = 0; i < this.PasswordLength; i++)
            {
                BuildingPw.Append(GetPasswordCharacter(passwordCharTypeList));

            }

            PasswordResult = BuildingPw.ToString();
            return PasswordResult;
        }
        public string GeneratePassword(int Length)
        {
            this.PasswordLength = Length;
            return GeneratePassword();
        }
        private string GetPasswordCharacter(List<PasswordCharacterType> PasswordCharTypeList)
        {
            // First we determine the type of character we need
            byte rndValue = GetRandomByte(PasswordCharTypeList.Count);
            int CharacterType = (int)rndValue % PasswordCharTypeList.Count;
            // Now that we now the type of charater we are generating, lets generate it
            rndValue = GetRandomByte(PasswordCharTypeList[CharacterType].length);
            int CharacterValue = (int)rndValue % PasswordCharTypeList[CharacterType].length;
            return PasswordCharTypeList[CharacterType].CharacterString[CharacterValue].ToString();
        }


        /// <summary>
        /// Gets a random byte which is withing a workable range based on RangeLength
        /// </summary>
        /// <param name="RangeLength">Value used to test usable range</param>
        /// <returns></returns>
        private byte GetRandomByte(int RangeLength)
        {
            byte[] rndValue = new byte[1];
            do
            {
                rng.GetBytes(rndValue);
            }
            while (!IsGoodNumber(rndValue[0], RangeLength));

            return rndValue[0];
        }
        /// <summary>
        /// Checks the generated number to ensure it falls within a working range based on the possible values
        /// </summary>
        /// <param name="rndNumber">The number to check</param>
        /// <param name="PossibleValues">Possible values randomizing against e.g. a-z = 26</param>
        /// <returns>True is rndNumber falls within a full set of values</returns>
        private bool IsGoodNumber(byte rndNumber, int PossibleValues)
        {
            int fullSetOfValues = byte.MaxValue / PossibleValues;
            // If testing against a-z, 26 values fullSetOfValues = 9. There are 9 full sets and one incomplete set.
            // We want to ensure that the random value is withing the full sets of values.
            return rndNumber < PossibleValues * fullSetOfValues;
        }
        /// <summary>
        /// Returns a list of requested character type objects based on properites set
        /// </summary>
        /// <returns></returns>
        private List<PasswordCharacterType> GetPasswordCharacterTypeList()
        {
            List<PasswordCharacterType> pctl = new List<PasswordCharacterType>();
            if (UseUpper) pctl.Add(new PasswordCharacterType("UpperAlpha", this.UpperAlpha));
            if (UseLower) pctl.Add(new PasswordCharacterType("LowerAlpha", this.LowerAlpha));
            if (UseNumbers) pctl.Add(new PasswordCharacterType("Numbers", this.Numbers));
            if (UsePunctuation) pctl.Add(new PasswordCharacterType("Punctuation", this.Punctuation));
            if (UseSpecial) pctl.Add(new PasswordCharacterType("Special", this.Special));

            return pctl;
        }

        #endregion

        #region Properties

        public string UpperAlpha 
        {
            get { return _UpperAlpha; }
            set 
            { 
                if (Utilities.PassCharacterValueParameterChecks(value, "PasswordGenerator.UpperAlpha"))    
                    _UpperAlpha = value; 
            }
                    
        }
        public string LowerAlpha 
        {
            get { return _LowerAlpha; }
            set 
            { 
                if (Utilities.PassCharacterValueParameterChecks(value, "PasswordGenerator.LowerAlpha"))
                    _LowerAlpha = value; 
            }
        }
        public string Numbers 
        {
            get { return _Numbers; }
            set 
            {
                if (Utilities.PassCharacterValueParameterChecks(value, "PasswordGenerator.Numbers")) 
                    _Numbers = value; 
            }
        }
        public string Punctuation 
        {
            get { return _Punctuation; }
            set 
            { 
                if (Utilities.PassCharacterValueParameterChecks(value, "PasswordGenerator.Punctuation"))
                _Punctuation = value; 
            }
        }
        public string Special 
        {
            get { return _Special; }
            set 
            { 
                if (Utilities.PassCharacterValueParameterChecks(value, "PasswordGenerator.Special"))
                _Special = value; 
            }
        }
        // --
        public int PasswordLength 
        { 
            get {return _PassowrdLength; }
            set
            {
                if (Utilities.IsPositiveInteger(value, "PasswordGenerator.PasswordLength"))
                    _PassowrdLength = value;
            }

        }
        public string PasswordResult { get; private set; }
        public string PasswordPhonetic { get; private set; }
        public bool UseUpper { get; set; }
        public bool UseLower { get; set; }
        public bool UseNumbers { get; set; }
        public bool UsePunctuation { get; set; }
        public bool UseSpecial { get; set; }

        // private 
        private string _UpperAlpha;
        private string _LowerAlpha;
        private string _Numbers;
        private string _Punctuation;
        private string _Special;
        private int _PassowrdLength;
        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        
        #endregion

        #region Constants
        public const string UPPER_ALPHA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string LOWER_ALPHA = "abcdefghijklmnopqrstuvwxyz";
        public const string NUMBERS = "0123456789";
        public const string PUNCTUATION = "!.?:;(){}[]";
        public const string SPECIAL = @"~@#$%^&*_-+=|\/';:<>,""";
        public const int DEFAULT_PASSWORD_LENGTH = 12;


        #endregion
    }
}
