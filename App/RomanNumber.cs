using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class RomanNumber
    {
        public int Value { get; set; }

        public static RomanNumber Parse(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }
            if (input == "N") return new();
            int prev = 0;
            int current;
            int result = 0;
            int lastDigitIndex = input[0] == '-' ? 1 : 0;
            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                current = input[i] switch
                {
                    'I' => 1,
                    'V' => 5,
                    'X' => 10,
                    'L' => 50,
                    'C' => 100,
                    'D' => 500,
                    'M' => 1000,
                };
                result += prev <= current ? current : -current;
                prev = current;
            }
            return new() { Value = result * (1 - 2 * lastDigitIndex) };
        }
    }
}
