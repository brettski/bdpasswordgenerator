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
            UseUpperAlpha = true;
            UseLowerAlpha = true;
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

            //PasswordResult = BuildingPw.ToString();
            //return PasswordResult;
            return BuildingPw.ToString();
        }
        public string GeneratePassword(int Length)
        {
            this.PasswordLength = Length;
            return GeneratePassword();
        }
        /// <summary>
        /// Returns a string List<> of passwords
        /// </summary>
        /// <param name="PasswordLength">Legnth of password to create</param>
        /// <param name="PasswordCount">Number of passwords to create</param>
        /// <returns>List<> of passwords</returns>
        public List<string> GeneratePasswordList(int PasswordLength, int PasswordCount)
        {
            if (!Utilities.IsPositiveInteger(PasswordLength, "PasswordGenerator.GenerateBulkPasswords>>PasswordLength"))
                return new List<string>(0);
            this.PasswordLength = PasswordLength;
            if (!Utilities.IsPositiveInteger(PasswordCount, "PasswordGenerator.GenerateBulkPasswords>>PasswordCount"))
                return new List<string>(0);
            if (!CurrentValuesAllowPossiblePwList(PasswordCount))
                return new List<string>(0);
            int count = (int)(PasswordCount * 0.01) + PasswordCount;
            this.PasswordLength = PasswordLength;
            System.Collections.Concurrent.ConcurrentQueue<string> pwdQueue = new System.Collections.Concurrent.ConcurrentQueue<string>();
            //List<string> FinalPwList = new List<string>(PasswordCount);
            HashSet<string> FinalPwSet = new HashSet<string>();
            string ts = string.Empty;
            Parallel.For(1, count, l =>
                {
                    pwdQueue.Enqueue(this.GeneratePassword());
                    
                });
            while (FinalPwSet.Count < PasswordCount)
            {
                if (!pwdQueue.IsEmpty)
                {
                    if (pwdQueue.TryDequeue(out ts))
                    {
                        //if(!FinalPwSet.Contains(ts))
                            FinalPwSet.Add(ts);
                    }
                }
                else
                {
                    ts = this.GeneratePassword(PasswordLength);
                    //if (!FinalPwSet.Contains(ts))
                        FinalPwSet.Add(ts);
                }

            }
            return FinalPwSet.ToList<string>();
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
            if (UseUpperAlpha) pctl.Add(new PasswordCharacterType("UpperAlpha", this.UpperAlpha));
            if (UseLowerAlpha) pctl.Add(new PasswordCharacterType("LowerAlpha", this.LowerAlpha));
            if (UseNumbers) pctl.Add(new PasswordCharacterType("Numbers", this.Numbers));
            if (UsePunctuation) pctl.Add(new PasswordCharacterType("Punctuation", this.Punctuation));
            if (UseSpecial) pctl.Add(new PasswordCharacterType("Special", this.Special));

            return pctl;
        }
        /// <summary>
        /// Verifies that there are enough total combinations of PasswordCharacterTypes to cover the number
        /// of requested passwords
        /// </summary>
        /// <param name="PasswordCount">Number of passwords requested to generate</param>
        /// <returns>result if values will allow the requested password list</returns>
        private bool CurrentValuesAllowPossiblePwList(int PasswordCount)
        {
            bool isOkay = true;
            int TotalPossibleValues = 0;
            if (UseUpperAlpha)
                TotalPossibleValues += UpperAlpha.Length;
            if (UseLowerAlpha)
                TotalPossibleValues += LowerAlpha.Length;
            if (UseNumbers)
                TotalPossibleValues += Numbers.Length;
            if (UsePunctuation)
                TotalPossibleValues += Punctuation.Length;
            if (UseSpecial)
                TotalPossibleValues += Special.Length;
            double tpvals = Math.Pow(TotalPossibleValues, TotalPossibleValues);
            double dvals = (double)(PasswordCount * PasswordLength);
            if ( tpvals < dvals )
            {
                isOkay = false;
                throw new ArgumentOutOfRangeException("PasswordCount", string.Format("There are not enough PassowrdCharacterType combinations to create {0} passwords with a length of {1}. Total:{2}, ToGenerate:{3}", PasswordCount, PasswordLength, tpvals, dvals));
            }
            tpvals = Math.Pow(TotalPossibleValues, PasswordLength);//TotalPossibleValues * PasswordCount;
            if (tpvals < dvals)
            {
                isOkay = false;
                throw new ArgumentOutOfRangeException("PasswordCount", string.Format("There are not enough possible combinations to create the password count you have selected. Total Possible:{0}, Total Requested:{1}", tpvals, PasswordCount));
            }
            return isOkay;
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
        //public string PasswordResult { get; private set; }
        public string PasswordPhonetic { get; private set; }
        public bool UseUpperAlpha { get; set; }
        public bool UseLowerAlpha { get; set; }
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
