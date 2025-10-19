using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_lesson4._1
{
    internal class C_lesson4_1
    {
        static void Main()
        {
            Console.WriteLine("Enter a number as a string:");
            string input = Console.ReadLine();

            try
            {
                int number = ConvertStringToInt(input);
                Console.WriteLine("Converted number: " + number);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: the number is out of the range of type int.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: invalid input. Please enter only digits.");
            }
        }

        static int ConvertStringToInt(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new FormatException();
            }

            int result = 0;
            bool isNegative = false;
            int i = 0;

            if (str[0] == '-')
            {
                isNegative = true;
                i = 1;
            }
            else if (str[0] == '+')
            {
                i = 1;
            }

            for (; i < str.Length; i++)
            {
                char c = str[i];
                if (c < '0' || c > '9')
                {
                    throw new FormatException();
                }

                int digit = c - '0';

                if (isNegative)
                {
                    if (result < (int.MinValue + digit) / 10)
                    {
                        throw new OverflowException();
                    }
                    result = result * 10 - digit;
                }
                else
                {
                    if (result > (int.MaxValue - digit) / 10)
                    {
                        throw new OverflowException();
                    }
                    result = result * 10 + digit;
                }
            }

            return result;
        }
    }
}
