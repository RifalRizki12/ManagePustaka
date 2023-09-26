using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePustaka
{
    public class Handler
    {
        public string ValidateInput(string validationMessage, Func<string, bool> isValid)
        {
            string input;
            bool isValidInput = false;

            do
            {
                Console.Write("Masukkan nilai: ");
                input = Console.ReadLine();

                if (isValid(input))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine(validationMessage);
                }
            } while (!isValidInput);

            return input;
        }

        public static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }
    }
}
