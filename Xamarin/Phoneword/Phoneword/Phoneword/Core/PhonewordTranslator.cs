
using System.Text;

namespace Phoneword.Core
{
    public class PhonewordTranslator : IPhonewordTranslator
    {
        private readonly string[] digits = {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        public string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                return null;
            }

            raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();
            foreach (var character in raw)
            {
                if (this.IsValidPhoneNumberCharacter(character))
                {
                    newNumber.Append(character);
                }
                else
                {
                    var result = this.TranslateLetterToNumber(character);
                    if (result != null)
                    {
                        newNumber.Append(result);
                    }
                    // Bad character?
                    else
                    {
                        return null;
                    }
                }
            }

            return newNumber.ToString();
        }

        private int? TranslateLetterToNumber(char character)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].IndexOf(character) >= 0)
                {
                    return 2 + i;
                }
            }

            return null;
        }

        private bool IsValidPhoneNumberCharacter(char character)
        {
            bool isValidPhoneNumberCharacter = " -0123456789".IndexOf(character) >= 0;

            return isValidPhoneNumberCharacter;
        }
    }
}
