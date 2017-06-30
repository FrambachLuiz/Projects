using System;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;


namespace DemoCode.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(0, 2)]
        [InlineData(-5, 1)]
        public void ShouldAdd_InlineData(int a, int b)
        {
            var sut = new Calculator();

            sut.Add(a);
            sut.Add(b);

            Assert.Equal(a + b, sut.Value);
        }


        [Theory]
        [AutoData] // AddTwoPositiveNumbers
        public void ShouldAdd_AutoData(int a, int b, Calculator sut)
        {
            sut.Add(a);
            sut.Add(b);

            Assert.Equal(a + b, sut.Value);
        }


        [Theory]
        [InlineAutoData] // AddTwoPositiveNumbers
        [InlineAutoData(0)] // AddZeroAndPositiveNumber
        [InlineAutoData(-5)] // AddNegativeAndPositiveNumber
        public void ShouldAdd_AutoInlineData_With_Sut(int a, int b, Calculator sut)
        {
            sut.Add(a);
            sut.Add(b);

            Assert.Equal(a + b, sut.Value);
        }    
    }
}
