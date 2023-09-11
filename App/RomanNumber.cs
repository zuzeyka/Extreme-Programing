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

        public RomanNumber(int value = 0) => Value = value;
        public static RomanNumber Parse(string input)
        {
            input = input?.Trim()!; // видалення початкових та кінцевих пробільних символів
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException(nameof(input));
            }
            input = input.Trim();
            if (input == "N") return new();
            int lastDigitIndex = input[0] == '-' ? 1 : 0;
            int maxDigit = 0;
            int lessDigitsCount = 0;
            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                int digitValue = DigitValue(input[i]);
                if (digitValue < maxDigit && ++lessDigitsCount > 1)
                    throw new ArgumentException(input);

                maxDigit = digitValue > maxDigit ? digitValue : maxDigit;
                lessDigitsCount = digitValue < maxDigit ? 1 : 0;
            }
            int prev = 0;
            int result = 0;
            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                char c = input[i];
                int current = DigitValue(c);

                if (current == 0)
                    throw new ArgumentException($"Invalid Roman digit in parse: '{c}'");
                result += prev <= current ? current : -current;
                prev = current;
            }
            return new() { Value = result * (1 - 2 * lastDigitIndex) };
        }
        public override string ToString()
        {
            // отобразить значение Value в виде римского числа (в оптимальном виде)
            Dictionary<int, string> parts = new()
            {
                { 1000, "M" },
                { 900, "CM" },
                { 600, "DC" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 6, "VI" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" }
            };
            if (Value == 0) return "N";
            bool isNegative = Value < 0;
            var number = isNegative ? -Value : Value;
            StringBuilder sb = new();
            if (isNegative) sb.Append("-");
            foreach (var part in parts)
            {
                while (number >= part.Key)
                {
                    sb.Append(part.Value);
                    number -= part.Key;
                }
            }
            return sb.ToString();
        }
        private static int DigitValue(char digit)
        {
            return digit switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new ArgumentException($"Invalid Roman digit in didgit: '{digit}'")
            };
        }
    }
}
