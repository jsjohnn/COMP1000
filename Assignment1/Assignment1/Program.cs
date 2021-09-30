using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //2.2.1 GetOnesComplementOrNull()
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("as89fdf0") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0xFAKEHEX") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0bFAKEBINARY") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("FAKEDECIMAL") == null);

            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0x") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0b") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("    ") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("-") == null);

            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("-10") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0xFC34") == null);

            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0b0000111010110") == "0b1111000101001");
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0b1000") == "0b0111");
            Debug.Assert(BigNumberCalculator.GetOnesComplementOrNull("0b0110101011101011100000") == "0b1001010100010100011111");

            //2.2.2 GetTwosComplementOrNull()
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b0000111010110") == "0b1111000101010");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b1000") == "0b1000");

            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0B") == null);
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b0") == "0b0");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b10") == "0b10");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b100") == "0b100");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b1000") == "0b1000");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b10000") == "0b10000");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b100000") == "0b100000");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b1000000") == "0b1000000");

            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b0") == "0b0");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b00") == "0b00");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b000") == "0b000");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b0000") == "0b0000");

            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b01") == "0b11");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b1") == "0b1");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b10") == "0b10");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b100") == "0b100");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b101") == "0b011");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b110") == "0b010");
            Debug.Assert(BigNumberCalculator.GetTwosComplementOrNull("0b111") == "0b001");

            //string temp = "+10";
            //int a = 0;
            //bool bBool = int.TryParse(temp, out a);

            //Console.WriteLine(bBool);


            //2.2.3 ToBinaryOrNull()
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0b00001101011") == "0b00001101011");
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0b") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0b-") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0bFAKENUM") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0xx0b") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0x") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0x00F24") == "0b00000000111100100100");

            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0b00001101011") == "0b00001101011");
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0x00F24") == "0b00000000111100100100");
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("123") == "0b01111011");
            string temp = BigNumberCalculator.ToBinaryOrNull("-123");
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-123") == "0b10000101");


            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-0") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0101") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0023") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("--11") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("00000000") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("+11") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0b0b") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0b0x") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0xx0b") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("    ") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("  24aA1  ") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull(" 123 3VXCa  ") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0bAA") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0b") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0x") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("KJDSLF:N(&#") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("#$@#$@#$") == null);
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("SER#$V@$V") == null);

            // D03_Decimal Input : Decimal -> Binary
            //Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-3") == "0b101");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("123"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("123") == "0b01111011");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-123"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-123") == "0b10000101");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("0"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("0") == "0b0");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("10"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("10") == "0b01010");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("100"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("100") == "0b01100100");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("1000"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("1000") == "0b01111101000");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("10000"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("10000") == "0b010011100010000");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-13579"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-13579") == "0b100101011110101");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-135799753113579") == "0b100001000111110110100111111101001000000000010101");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-9223372036854775808")); // long.minvalue
            //Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-9223372036854775808") == "0b1000000000000000000000000000000000000000000000000000000000000000");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("                                                 "));
            //Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-9223372036854775809") == "0b10111111111111111111111111111111111111111111111111111111111111111");
            //Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-9223372036854775810"));
            //Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-9223372036854775810") == "0b10111111111111111111111111111111111111111111111111111111111111110");
            Console.WriteLine($"{BigNumberCalculator.ToBinaryOrNull(int.MaxValue.ToString())}");
            Console.WriteLine($"{BigNumberCalculator.ToBinaryOrNull((int.MinValue + 1).ToString())}");
            Console.WriteLine($"{BigNumberCalculator.ToBinaryOrNull(int.MinValue.ToString())}");
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

            //for (long i = -1; i < 1; ++i)
            //{
            //    Console.WriteLine(i);
            //    string binary = Convert.ToString(i, 2);
            //    binary = binary.Insert(0, "0b");
            //    Console.WriteLine($"std : {binary}");
            //    Console.WriteLine($"{i} : 
            //}

            //Power of two//
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("1") == "0b01");
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("2") == "0b010");
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("4") == "0b0100");
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("8") == "0b01000");
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("16") == "0b010000");
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("32") == "0b0100000");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-1"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-1") == "0b1");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-2"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-2") == "0b10");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-4"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-4") == "0b100");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-8"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-8") == "0b1000");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-16"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-16") == "0b10000");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull("-32"));
            Debug.Assert(BigNumberCalculator.ToBinaryOrNull("-32") == "0b100000");

        }
    }
}
