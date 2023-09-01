using App; // добавить зависимость (Dependencies - Project Reference) от проэкта App

namespace Tests
{
    [TestClass]
    public class UnitTestApp
    {
        [TestMethod]
        public void TestRomanNumberParse()
        {
            Assert
                .AreEqual(// RomanNumber.Parse("I").Value == 1;
                1, // Значения которое ожидается (что должен быть правильный выбор)
                RomanNumber.Parse("I").Value, // Актуальное значение
                "1 == I"); // Сообщение о провале теста
            Assert
                .AreEqual(// RomanNumber.Parse("II").Value == 2;
                2,
                RomanNumber.Parse("II").Value,
                "2 == II");
        }
    }
}
/* Основу модульных тестом состовляют утверждения (Asserts).
В утверждении фигурируют два значения: те, которые ожидаются, и те, которые получаются.
Большинство тестов проверяют равность (объектную или контентную),
или в сокрощенной форме (IsTrue, IsNotNull, ...)
*/
