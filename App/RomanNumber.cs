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

        private static Dictionary<string, int>
            romanNumerals =
                new Dictionary<string, int>() { { "I", 1 }, { "II", 2 } };

        public static RomanNumber Parse(string input)
        {
            if (romanNumerals.TryGetValue(input, out int value))
            {
                return new RomanNumber { Value = value };
            }
            else
            {
                return new RomanNumber { Value = 0 };
            }
        }
    }
}
