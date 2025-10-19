using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_lesson4._4
{
    internal class C_lesson4_4
    {
        static void Main()
        {
            Console.WriteLine("Enter a mathematical expression with numbers and * (for example: 3*2*1*4):");
            string input = Console.ReadLine();

            try
            {
                int result = CalculateMultiplication(input);
                Console.WriteLine("Result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static int CalculateMultiplication(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new Exception("Empty line! Enter an expression.");
            }

            string[] parts = expression.Split('*');

            int result = 1;

            foreach (string part in parts)
            {
                if (!int.TryParse(part.Trim(), out int number))
                {
                    throw new Exception("Incorrect number: " + part);
                }

                result *= number;
            }

            return result;
        }
    }
}
