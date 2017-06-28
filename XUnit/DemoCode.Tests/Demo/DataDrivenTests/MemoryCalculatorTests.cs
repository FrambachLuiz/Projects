using DemoCode.Tests.Demo.DataDrivenTests;
using Xunit;

namespace DemoCode.Tests
{
    public class MemoryCalculatorTests
    {

        [Theory]
        [CsvTestData("TestData.csv")]
        public void ShouldSubstractTwoNumbers(int firstNumber, int secondNumber, int expectedResult)
        {
            var sut = new MemoryCalculator();

            sut.Subtract(firstNumber);
            sut.Subtract(secondNumber);

            Assert.Equal(expectedResult, sut.CurrentValue);
        }
    }
}