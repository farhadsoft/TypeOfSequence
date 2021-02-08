using System;
using System.Collections.Generic;

namespace Numbers
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Obtains formalized information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number. 
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number
        /// or null if the information is not defined.</returns>
        public static ComparisonSigns? GetTypeComparisonSigns(this long number)
        {
            int result = GetSum(GetDigits(number));

            switch (result)
            {
                case 1:
                    return ComparisonSigns.LessThan;
                case 2:
                    return ComparisonSigns.MoreThan;
                case 3:
                    return ComparisonSigns.LessThan | ComparisonSigns.MoreThan;
                case 4:
                    return ComparisonSigns.Equals;
                case 5:
                    return ComparisonSigns.LessThan | ComparisonSigns.Equals;
                case 6:
                    return ComparisonSigns.MoreThan | ComparisonSigns.Equals;
                case 7:
                    return ComparisonSigns.LessThan | ComparisonSigns.MoreThan | ComparisonSigns.Equals;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Gets information in the form of a string about the type of sequence that the digit of a given number represents.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The information in the form of a string about the type of sequence that the digit of a given number represents.</returns>
        public static string GetTypeOfDigitsSequence(this long number)
        {
            int result = GetSum(GetDigits(number));

            switch (result)
            {
                case 1:
                    return "Strictly Increasing.";
                case 2:
                    return "Strictly Decreasing.";
                case 3:
                    return "Unordered.";
                case 4:
                    return "Monotonous.";
                case 5:
                    return "Increasing.";
                case 6:
                    return "Decreasing.";
                case 7:
                    return "Unordered.";
                default:
                    return "One digit number.";
            }
        }

        public static int GetSum(List<long> list)
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            int result = 0;
            bool more = false;
            bool less = false;
            bool equal = false;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1] < list[i] && !more)
                {
                    result += 2;
                    more = true;
                }
                else if (list[i - 1] > list[i] && !less)
                {
                    result += 1;
                    less = true;
                }
                else if (list[i - 1] == list[i] && !equal)
                {
                    result += 4;
                    equal = true;
                }
            }

            return result;
        }

        public static List<long> GetDigits(long source)
        {
            List<long> list = new List<long>();
            while (source != 0)
            {
                long digit = source % 10;
                source /= 10;
                list.Add(digit);
            }

            return list;
        }
    }
}
