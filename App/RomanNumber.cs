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
        public static RomanNumber Parse(String input)
        {
            var value = 0;
            switch (input)
            {
                case "I":
                    value = 1;
                    break;
                case "II":
                    value = 2;
                    break;
                default:
                    value = 0;
                    break;
            }
            return new()
            {
                Value = value
            };
        }
    }
}
