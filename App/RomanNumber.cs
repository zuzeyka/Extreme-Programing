using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace App
{
    public class RomanNumber
    {
        public int Value { get; set; }
        public RomanNumber(int value = 0)
        {
            Value = value;
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
                'N' => 0,
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new ArgumentException($"Invalid Roman didgit in digit: '{digit}'")
            };
        }

        private static void CheckLegalityOrThrow(String input)
        {
            int maxDigit = 0;
            int lessDigitsCount = 0;
            int lastDigitIndex = input.StartsWith('-') ? 1 : 0;
            int digitValue = 0;

            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                digitValue = DigitValue(input[i]);
                if (digitValue < maxDigit && ++lessDigitsCount > 1)
                    throw new ArgumentException(input);

                maxDigit = digitValue > maxDigit ? digitValue : maxDigit;
                lessDigitsCount = digitValue < maxDigit ? 1 : 0;
            }
        }

        private static void CheckValidityOrThrow(String input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Null or empty input");
            }
            if (input.StartsWith('-'))
                input = input[1..];
            List<char> invalidChars = new();
            foreach (char c in input)
            {
                try { DigitValue(c); }
                catch { invalidChars.Add(c); }
            }
            if (invalidChars.Count > 0)
            {
                String chars = String.Join(", ", invalidChars.Select(
                    c => $"'{c}'"));
                throw new ArgumentException($"Invalid Roman didgit in digits: {chars}");
            }
        }

        public static RomanNumber Parse(String input)
        {

            input = input?.Trim()!; // удаление начальных и конечных пробелов

            CheckValidityOrThrow(input);
            CheckLegalityOrThrow(input);
            if (input == "N") return new();

            int lastDigitIndex = input[0] == '-' ? 1 : 0;

            int prev = 0;
            int result = 0;
            int current = 0;


            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {

                //if (current == 0)
                //    throw new ArgumentException($"Invalid Roman digit in parse: '{input[i]}'");
                current = DigitValue(input[i]);
                result += prev > current ? -current : current;
                prev = current;
            }



            return new()
            {
                Value = result * (1 - 2 * lastDigitIndex)
            };
            //input.Length для тестов
            /*input switch 
            { 
                "I" => 1,
                "II" => 2,
                _ => 3,
            } 
            //input == "I" ? 1 : 2*/
            /* Правило "чтения" римских чисел:
              * Если цифра предшествует большей цифре, то она вычитается (IV, IX)
              * Меньший, или ровный - прилагается (VI, XI, II)
              * Остальные правила игнорируем - делаем максимально "дружественный" интерфейс
              *
              * Алгоритм – "заходим" из правой цифры, ее всегда добавляем, запоминаем
              * и дальше сравниваем со следующей цифрой.
              */
        }

    }
}


