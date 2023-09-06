using App; // добавить зависимость (Dependencies - Project Reference) от проэкта App

namespace Tests
{
    [TestClass]
    public class UnitTestApp
    {
        [TestMethod]
        public void RandomTest()
        {
            const int minRange = -3000;
            const int maxRange = 3000;
            
            var random = new Random();
            
            for (int i = 0; i < 256; i++)
            {
                int num = random.Next(minRange, maxRange);
                Assert.AreEqual(num, RomanNumber.Parse(new RomanNumber(num).ToString()).Value, $"num = {num}");
            }
        }

        [TestMethod]
        public void TestToString()
        {
            Dictionary<int, String> testCases = new()
            {
                {0      ,   "N" },
                {1      ,   "I" },
                {2      ,   "II" },
                {3      ,   "III" },
                {4      ,   "IV" },
                {5      ,   "V" },
                {6      ,   "VI" },
                {7      ,   "VII" },
                {8      ,   "VIII" },
                {9      ,   "IX" },
                {10     ,   "X" },
                {11     ,   "XI" },
                {12     ,   "XII" },
                {13     ,   "XIII" },
                {14     ,   "XIV" },
                {15     ,   "XV" },
                {16     ,   "XVI" },
                {17     ,   "XVII" },
                {18     ,   "XVIII" },
                {19     ,   "XIX" },
                {20     ,   "XX" },
                {21     ,   "XXI" },
                {22     ,   "XXII" },
                {23     ,   "XXIII" },
                {29     ,   "XXIX"},
                {30     ,   "XXX" },
                {33     ,   "XXXIII" },
                {39     ,   "XXXIX"},
                {40     ,   "XL" },
                {44     ,   "XLIV" },
                {48     ,   "XLVIII" },
                {50     ,   "L" },
                {51     ,   "LI" },
                {52     ,   "LII" },
                {55     ,   "LV" },
                {59     ,   "LIX" },
                {62     ,   "LXII" },
                {64     ,   "LXIV" },
                {66     ,   "LXVI" },
                {75     ,   "LXXV" },
                {77     ,   "LXXVII" },
                {81     ,   "LXXXI" },
                {88     ,   "LXXXVIII" },
                {90     ,   "XC" },
                {92     ,   "XCII" },
                {99     ,   "XCIX" },
                {100    ,   "C" },
                {105    ,   "CV" },
                {107    ,   "CVII" },
                {111    ,   "CXI" },
                {115    ,   "CXV" },
                {123    ,   "CXXIII" },
                {222    ,   "CCXXII" },
                {234    ,   "CCXXXIV" },
                {246    ,   "CCXLVI"},
                {321    ,   "CCCXXI" },
                {333    ,   "CCCXXXIII" },
                {345    ,   "CCCXLV" },
                {378    ,   "CCCLXXVIII"},
                {404    ,   "CDIV" },
                {444    ,   "CDXLIV" },
                {456    ,   "CDLVI" },
                {500    ,   "D" },
                {555    ,   "DLV" },
                {567    ,   "DLXVII" },
                {609    ,   "DCIX" },
                {666    ,   "DCLXVI" },
                {678    ,   "DCLXXVIII" },
                {777    ,   "DCCLXXVII" },
                {789    ,   "DCCLXXXIX" },
                {888    ,   "DCCCLXXXVIII" },
                {890    ,   "DCCCXC" },
                {901    ,   "CMI" },
                {999    ,   "CMXCIX" },
                {1000   ,   "M" },
                {1007   ,   "MVII" },
                {1111   ,   "MCXI" },
                {1199   ,   "MCXCIX"},
                {1234   ,   "MCCXXXIV" },
                {1317   ,   "MCCCXVII" },
                {1350   ,   "MCCCL"},
                {1432   ,   "MCDXXXII" },
                {1500   ,   "MD" },
                {1575   ,   "MDLXXV" },
                {1632   ,   "MDCXXXII" },
                {1667   ,   "MDCLXVII" },
                {1734   ,   "MDCCXXXIV" },
                {1872   ,   "MDCCCLXXII" },
                {1969   ,   "MCMLXIX" },
                {1985   ,   "MCMLXXXV" },
                {2023   ,   "MMXXIII" },
                {2048   ,   "MMXLVIII" },
                {2107   ,   "MMCVII" },
                {2184   ,   "MMCLXXXIV" },
                {2222   ,   "MMCCXXII" },
                {2247   ,   "MMCCXLVII"},
                {2288   ,   "MMCCLXXXVIII" },
                {2345   ,   "MMCCCXLV" },
                {2392   ,   "MMCCCXCII" },
                {2496   ,   "MMCDXCVI" },
                {2499   ,   "MMCDXCIX"},
                {2500   ,   "MMD" },
                {2678   ,   "MMDCLXXVIII" },
                {2700   ,   "MMDCC"},
                {2781   ,   "MMDCCLXXXI" },
                {2884   ,   "MMDCCCLXXXIV" },
                {2958   ,   "MMCMLVIII" },
                {2999   ,   "MMCMXCIX"},
                {3000   ,   "MMM" },
                {-23, "-XXIII" },
                {-169, "-CLXIX" },
                {-313, "-CCCXIII" },
                {-996, "-CMXCVI" },
                {-1272, "-MCCLXXII" },
                {-1456, "-MCDLVI" },
                {-1603, "-MDCIII" },
                {-1674, "-MDCLXXIV" },
                {-1718, "-MDCCXVIII" },
                {-1742, "-MDCCXLII" },
                {-1747, "-MDCCXLVII" },
                {-1784, "-MDCCLXXXIV" },
                {-1785, "-MDCCLXXXV" },
                {-1796, "-MDCCXCVI" },
                {-1884, "-MDCCCLXXXIV" },
                {-1945, "-MCMXLV" },
                {-1951, "-MCMLI" },
                {-1968, "-MCMLXVIII" },
                {-1972, "-MCMLXXII" },
                {-1980, "-MCMLXXX" },
                {-1982, "-MCMLXXXII" },
                {-2142, "-MMCXLII" },
                {-2266, "-MMCCLXVI" },
                {-2510, "-MMDX" },
                {-2727, "-MMDCCXXVII" },
                {-2730, "-MMDCCXXX" },
                {-2756, "-MMDCCLVI" },
                {-2767, "-MMDCCLXVII" },
                {-2777, "-MMDCCLXXVII" },
                {-2799, "-MMDCCXCIX" },
                {-2814, "-MMDCCCXIV" },
                {-2947, "-MMCMXLVII" },
                {-2970, "-MMCMLXX" },
                {-2987, "-MMCMLXXXVII" },
                {-2998, "-MMCMXCVIII"},
            };
            foreach (var pair in testCases)
            {
                Assert.AreEqual(pair.Value, new RomanNumber(pair.Key).ToString(),
                $"{pair.Key}.ToString() == '{pair.Value}'");
            }
            Assert.AreEqual("N", new RomanNumber().ToString(), $"new RomanNumber().ToString() == 'N'");
        }
        private static Dictionary<string, int>
            parseTest =
                new Dictionary<string, int>()
                {
                    { "I", 1 },
                    { "II", 2 },
                    { "III", 3 },
                    { "IIII", 4 },
                    { "IV", 4 },
                    { "V", 5 },
                    { "VI", 6 },
                    { "VII", 7 },
                    { "VIII", 8 },
                    { "IX", 9 },
                    { "X", 10 },
                    { "VV", 10 },
                    { "IIIIIIIIII", 10 },
                    { "VX", 5 },
                    { "N", 0 },
                    { "-L", -50 },
                    { "-XL", -40 },
                    { "-IL", -49 },
                    { "-D", -500 },
                    { "-C", -100 },
                    { "-M", -1000 },
                    { "D", 500 },
                    { "C", 100 },
                    { "M", 1000 },
                    { "IM", 999 },
                    { "-IM", -999 },
                    { "IC", 99 },
                    { "-IC", -99 },
                    { "ID", 499 },
                    { "-ID", -499 },
                    { "VM", 995 },
                    { "-VM", -995 },
                    { "VC", 95 },
                    { "-VC", -95 },
                    { "VD", 495 },
                    { "-VD", -495 },
                    { "XM", 990 },
                    { "-XM", -990 },
                    { "XC", 90 },
                    { "-XC", -90 },
                    { "XD", 490 },
                    { "-XD", -490 },
                    { "MI", 1001 },
                    { "-MI", -1001 },
                    { "CI", 101 },
                    { "-CI", -101 },
                    { "DI", 501 },
                    { "-DI", -501 },
                    { "MV", 1005 },
                    { "-MV", -1005 },
                    { "CV", 105 },
                    { "-CV", -105 },
                    { "DV", 505 },
                    { "-DV", -505 },
                    { "MX", 1010 },
                    { "-MX", -1010 },
                    { "CX", 110 },
                    { "-CX", -110 },
                    { "DX", 510 },
                    { "-DX", -510 },
                    { "LX", 60 },
                    { "LXII", 62 },
                    { "CCL", 250 },
                    { "-CCIII", -203 },
                    { "-LIV", -54 },
                    { "MDII", 1502 },
                    { "DD", 1000 },
                    { "CCCCC", 500 },
                    { "IVIVIVIVIV", 20 },
                    { "MMMMMMMMMM", 10000 },
                    { "-MMMMMMMMMM", -10000 },
                    { "VVVVVVVVVV", 50 },
                    { "-VVVVVVVVVV", -50 },
                    { "XX", 20 },
                    { "XXI", 21 },
                    { "XXII", 22 },
                    { "XXIII", 23 },
                    { "XXIV", 24 },
                    { "XXV", 25 },
                    { "XXVI", 26 },
                    { "XXVII", 27 },
                    { "XXVIII", 28 },
                    { "XXIX", 29 },
                    { "XXX", 30 },
                    { "XXXI", 31 },
                    { "XXXII", 32 },
                    { "XXXIII", 33 },
                    { "XXXIV", 34 },
                    { "XXXV", 35 },
                    { "XXXVI", 36 },
                    { "XXXVII", 37 },
                    { "XXXVIII", 38 },
                    { "XXXIX", 39 },
                    { "XXXX", 40 },
                    { "XXXXI", 41 },
                    { "XXXXII", 42 },
                    { "XXXXIII", 43 },
                    { "XXXXIV", 44 },
                    { "XXXXV", 45 },
                    { "XXXXVI", 46 },
                    { "XXXXVII", 47 },
                    { "XXXXVIII", 48 },
                    { "XXXXIX", 49 },
                    { "XXXXV ", 45 },
                    { " XXXXVI ", 46 },
                    { "\nXXXXVIII\t", 48 },
                };

        [TestMethod]
        public void TestRomanNumberParseValid()
        {
            Assert.AreEqual(1, RomanNumber.Parse("I").Value, "1 == I");

            foreach (var item in parseTest)
            {
                Assert
                    .AreEqual(item.Value,
                    RomanNumber.Parse(item.Key).Value,
                    $"{item.Value} == {item.Key}");
            }
        }

        [TestMethod]
        public void TestRomanNumberParseNonValid()
        {
            // Тестирование с неправильными формами чисел
            Assert
                .ThrowsException<ArgumentException>(() => RomanNumber.Parse(""),
                " -> ArgumentException");
            Assert
                .ThrowsException<ArgumentException>(() => RomanNumber.Parse(null!),
                "null -> ArgumentException");
            // самое исключение которое произошло в лямде возвращается как результат
            var ex = Assert
                .ThrowsException<ArgumentException>(() => RomanNumber.Parse("XBC"),
                "'' -> ArgumentException");
            // требуем чтобы ведомости про неправильную цифру были включенны в сообщение исключения
            Assert.IsTrue(ex.Message.Contains("'B'"), "ex.Message sould contains 'B' ");
            String testCase = "Xx";
            Dictionary<string, char> testCases = new()
            {
                { "Xx", 'x' },
                { "Xy", 'y' },
                { "AX", 'A' },
                { "X C", ' ' },
                { "X\tC", '\t' },
                { "X\nC", '\n' }
            };
            foreach (var pair in testCases)
            {
                // избавляемся от переменной ex - делаем вложенные выражения
                Assert.IsTrue(Assert.ThrowsException<ArgumentException>(
                () => RomanNumber.Parse(pair.Key),
                $"'{pair.Key}' -> ArgumentException").Message.Contains($"'{pair.Value}'"),
                $"'{pair.Key}' ex.Message sould contains '{pair.Value}'");
            }
            // Если неправильных цифр несколько, то ми ожидаем любую из них
            // "ABC" - или 'A', или 'B'
            ex = Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("ABC"), "'' -> ArgumentException");
            Assert.IsTrue(ex.Message.Contains("'A'") || ex.Message.Contains("'B'"), "ex.Message sould contains 'B' or 'A'");
            // + проверим, что уведомления (исключения) не сильно короткое
            // язык или другие слова не устанавливаем, но чтобы длина была больше 15
            Assert.IsFalse(ex.Message.Length < 15, "ex.Message sould be more than 15");
        }
    }
}
/*
Тестирование исключений (Exceptions)
У системы тестирования исключений - провалы теста.
Поэтому выражения, которые должны завершиться с исключением, окружают функциональными выражениями (лямбдами). Это позволяет
перенести появления исключения в середину тестового метода, 
где оно будет обработано нужным образом.
Особенности:
 - проверяется строгое совпадение типов исключений,
 более абстрактный тип не засчитывается как прохождение теста
 - тест возвращает вызваное исключение, жто позволяет наложить условия на сообщение, причину и.т.д.


Слушание:
какие из комбинаций считать правильными, какие нет
'X C', 'XC', 'XC ', 'XC\t', '\nXC', 'XC\n', 'X\nC'
*/
/* Основу модульных тестом состовляют утверждения (Asserts).
В утверждении фигурируют два значения: те, которые ожидаются, и те, которые получаются.
Большинство тестов проверяют равность (объектную или контентную),
или в сокрощенной форме (IsTrue, IsNotNull, ...)
*/
