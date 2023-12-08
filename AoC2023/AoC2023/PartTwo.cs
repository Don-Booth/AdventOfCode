using System.ComponentModel.Design;
using System.Diagnostics;

namespace Day1
{
    internal class PartTwo
    {
        #region Puzzle Text
        /*
            --- Part Two ---
            Your calculation isn't quite right. It looks like some of the digits are actually spelled out with letters: one, two, three, four, five, six, seven, eight, and nine also count as valid "digits".

            Equipped with this new information, you now need to find the real first and last digit on each line. For example:

            two1nine
            eightwothree
            abcone2threexyz
            xtwone3four
            4nineeightseven2
            zoneight234
            7pqrstsixteen
            In this example, the calibration values are 29, 83, 13, 24, 42, 14, and 76. Adding these together produces 281.

            What is the sum of all of the calibration values?

            The right answer is 54249
        */
        #endregion

        public static int GetPartTwoAnswer(string fileName)
        {
            int grandTotal = 0;
            string[] numberStrings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            foreach (string line in File.ReadLines(fileName))
            {
                string num1a = String.Empty;
                string num1b = String.Empty;
                string num2a = String.Empty;
                string num2b = String.Empty;
                string result1 = String.Empty;
                string result2 = String.Empty;
                string result = String.Empty;
                int sum = 0;
                int num1aIndex = -1;
                int num1bIndex = line.Length;
                int num2aIndex = -1;
                int num2bIndex = 0;

                #region numbers
                num1aIndex = line.IndexOfAny("0123456789".ToCharArray());
                if (num1aIndex > -1) num1a = line.Substring(num1aIndex, 1);

                num2aIndex = line.LastIndexOfAny("0123456789".ToCharArray());
                if (num2aIndex > -1) num2a = line.Substring(num2aIndex, 1);
                #endregion

                #region letters
                foreach (string numberString in numberStrings)
                { 
                    int index = line.IndexOf(numberString);

                    if (index > -1 && index < num1bIndex)
                    {
                        num1b = numberString;
                        num1bIndex = index;
                    }
                }

                if (num1b == String.Empty)
                    num1bIndex = line.Length;
                else
                    num1b = ConvertToNumber(num1b);

                foreach (string numberString in numberStrings) 
                { 
                    int index = line.LastIndexOf(numberString);

                    if (index > -1 && index > num2bIndex)
                    { 
                        num2b = numberString;
                        num2bIndex = index;
                    }
                }

                if (num2b == string.Empty)
                    num2bIndex = -1;
                else
                    num2b = ConvertToNumber(num2b);
                #endregion

                if (num1aIndex < num1bIndex)
                    result1 = num1a;
                else
                    result1 = num1b;

                if (num2aIndex > num2bIndex)
                    result2 = num2a;
                else
                    result2 = num2b;

                result = result1 + result2;
                sum = int.Parse(result);
                grandTotal += sum;
            }

            return grandTotal; 
        }

        private static string ConvertToNumber(string numberToConvert)
        {
            string result = String.Empty;

            switch (numberToConvert) 
            {
                case "zero":
                    result = "0";
                    break;
                case "one":
                    result = "1";
                    break;
                case "two":
                    result = "2";
                    break;
                case "three":
                    result = "3";
                    break;
                case "four":
                    result = "4";
                    break;
                case "five":
                    result = "5";
                    break;
                case "six":
                    result = "6";
                    break;
                case "seven":
                    result = "7";
                    break;
                case "eight":
                    result = "8";
                    break;
                case "nine":
                    result = "9";
                    break;
            }

            return result;
        }
    }
}
