using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class ISBNFormatAttribute : ValidationAttribute
    {
        public string FirstMask { get; private set; }
        public string SecondMask { get; private set; }

        public ISBNFormatAttribute(string firstFormat, string secondFormat)
        {
            FirstMask = firstFormat;
            SecondMask = secondFormat;
        }


        public override bool IsValid(object value)
        {
            var number = (string)value;

            if (FirstMask != null && SecondMask != null)
            {
                return MatchesFormat(FirstMask, number) || MatchesFormat(SecondMask, number);
            }

            return true;
        }

        internal bool MatchesFormat(string mask, string number)
        {
            if (mask.Length != number.Trim().Length)
            {
                return false;
            }

            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] == 'X' && char.IsDigit(number[i]) == false)
                {
                    return false;
                }

                if (mask[i] == '-' && number[i] != '-')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
