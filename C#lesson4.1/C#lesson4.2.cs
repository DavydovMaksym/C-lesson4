using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_lesson4._2
{
    internal class C_lesson4_2
    {
        static int ConvertBinaryToInt(string binary)
        {
            if (string.IsNullOrEmpty(binary))
            {
                throw new FormatException();
            }

            int result = 0;

            for (int i = 0; i < binary.Length; i++)
            {
                char c = binary[i];
                if (c != '0' && c != '1')
                {
                    throw new FormatException();
                }

                int bit = c - '0';

                if (result > (int.MaxValue - bit) / 2)
                {
                    throw new OverflowException();
                }

                result = result * 2 + bit;
            }

            return result;
        }

        static void Main()
        {
            Console.WriteLine("Enter a binary number (only 0s and 1s):");
            string input = Console.ReadLine();

            try
            {
                int number = ConvertBinaryToInt(input);
                Console.WriteLine("Decimal value: " + number);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: the number is out of the range of type int.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: invalid input. Enter only 0s and 1s.");
            }
        }
    }
}
