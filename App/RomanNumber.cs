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
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException(nameof(input));
            }
            input = input.Trim();
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
                    _ => throw new ArgumentException($"Invalid Roman digit: '{input[i]}'")
                };
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
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
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
    }
}
