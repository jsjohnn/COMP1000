using System;
using System.Text;
using System.Collections.Generic;
namespace Assignment1
{
    public class BigNumberCalculator
    {
        public BigNumberCalculator(int bitCount, EMode mode)
        {
        }

        public static string GetOnesComplementOrNull(string num)
        {
            if (string.IsNullOrEmpty(num) || num.Length < 3)
            {
                return null;
            }
            string notation = num.Substring(0, 2);
            string binaryNotation = "0b";

            if (notation != binaryNotation)
            {
                return null;
            }

            int length = num.Length - 2;
            string val = num.Substring(2, length);

            for (int i = 0; i < val.Length; ++i)
            {
                if (val[i] != '0' && val[i] != '1')
                {
                    return null;
                }
            }

            StringBuilder reverseVal = new StringBuilder();
            reverseVal.Append("0b");

            for (int i = 0; i < val.Length; ++i)
            {
                if (val[i] == '0')
                {
                    reverseVal.Append(1);
                }
                else
                {
                    reverseVal.Append(0);
                }
            }

            return reverseVal.ToString();
        }

        public static string GetTwosComplementOrNull(string num)
        {
            if (BigNumberCalculator.GetOnesComplementOrNull(num) == null)
            {
                return null;
            }

            string onesComplementValue = BigNumberCalculator.GetOnesComplementOrNull(num);

            string binaryValue = onesComplementValue.Substring(2, num.Length - 2);

            StringBuilder reverseTwoComplement = new StringBuilder();

            int temp = 1;

            for (int i = binaryValue.Length - 1; i >= 0; --i)
            {
                int val = binaryValue[i] == 49 ? 1 : 0;

                if (val + temp > 1)
                {
                    reverseTwoComplement.Append(0);
                    temp = 1;
                }
                else
                {
                    reverseTwoComplement.Append(val + temp);
                    temp = 0;
                }
            }

            reverseTwoComplement.Append("b0");
            string TwoComplementValue = reverseTwoComplement.ToString();
            StringBuilder TwoComplement = new StringBuilder(reverseTwoComplement.Length);

            for (int i = 0; i < TwoComplementValue.Length; ++i)
            {
                TwoComplement.Append(TwoComplementValue[TwoComplementValue.Length - 1 - i]);
            }

            return TwoComplement.ToString();
        }

        #region ToBinaryOrNull  
        public static string ToBinaryOrNull(string num)
        {
            if (string.IsNullOrEmpty(num) || num[0] == '+' || num == "-0")
            {
                return null;
            }

            string notation = "";
            if (num.Length > 1)
            {
                notation = num.Substring(0, 2);
            }

            if (notation == "0b")
            {
                if (num.Length < 3)
                {
                    return null;
                }

                int binaryValueLength = num.Length - 2;
                string binaryValueForCheck = num.Substring(2, binaryValueLength);
                int binaryValue;

                if (!int.TryParse(binaryValueForCheck, out binaryValue))
                {
                    return null;
                }
                else
                {
                    return num;
                }
            }
            else if (notation == "0x")
            {
                if (num.Length < 3)
                {
                    return null;
                }

                int hexValueLength = num.Length - 2;
                string hexValueForCheck = num.Substring(2, hexValueLength);

                for (int i = 0; i < hexValueLength; ++i)
                {
                    if (!(hexValueForCheck[i] >= 48 && hexValueForCheck[i] <= 57
                        || hexValueForCheck[i] >= 65 && hexValueForCheck[i] <= 70))
                    {
                        return null;
                    }
                }

                Dictionary<char, string> temp = new Dictionary<char, string>(15)
                {
                    { '0', "0000"},{ '1', "0001"},{ '2', "0010"},{ '3', "0011"},{ '4', "0100"},
                    { '5', "0101"},{ '6', "0110"},{ '7', "0111"},{ '8', "1000"},{ '9', "1001"},
                    { 'A', "1010"},{ 'B', "1011"},{ 'C', "1100"},{ 'D', "1101"},{ 'E', "1110"},{ 'F', "1111"}
                };

                StringBuilder tempHexToBinary = new StringBuilder();
                tempHexToBinary.Append("0b");

                for (int i = 0; i < hexValueLength; ++i)
                {
                    tempHexToBinary.Append(temp[hexValueForCheck[i]]);
                }

                return tempHexToBinary.ToString();
            }
            else
            {
                if (num[0] == '0' && num.Length > 1)
                {
                    return null;
                }

                if (num == "0")
                {
                    return "0b0";
                }

                long decimalValue;

                if (!long.TryParse(num, out decimalValue))
                {
                    return null;
                }

                StringBuilder binaryPattern = new StringBuilder();
                binaryPattern.Append("0b0");

                if (decimalValue > 0)
                {
                    binaryPattern = DecimalToBinary(decimalValue, binaryPattern);
                    return binaryPattern.ToString();
                }
                else
                {
                    decimalValue *= -1;
                    binaryPattern = DecimalToBinary(decimalValue, binaryPattern);
                    return GetTwosComplementOrNull(binaryPattern.ToString());
                }

            }

        }
        #endregion

        public static string ToHexOrNull(string num)
        {

            return null;
        }

        public static string ToDecimalOrNull(string num)
        {
            return null;
        }

        public string AddOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            return null;
        }

        public string SubtractOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            return null;
        }

        private static StringBuilder DecimalToBinary(long num, StringBuilder sb)
        {
            if (num == 0 || num == 1)
            {
                return sb.Append(num);
            }

            long remainder = num % 2;
            num = num / 2;

            DecimalToBinary(num, sb);

            return sb.Append(remainder);
        }
    }
}