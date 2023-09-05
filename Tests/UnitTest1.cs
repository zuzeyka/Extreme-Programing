using App; // добавить зависимость (Dependencies - Project Reference) от проэкта App

namespace Tests
{
    [TestClass]
    public class UnitTestApp
    {
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
                    { "XXXXIX", 49 }
                };

        [TestMethod]
        public void TestRomanNumberParse()
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
    }
}
/* Основу модульных тестом состовляют утверждения (Asserts).
В утверждении фигурируют два значения: те, которые ожидаются, и те, которые получаются.
Большинство тестов проверяют равность (объектную или контентную),
или в сокрощенной форме (IsTrue, IsNotNull, ...)
*/
