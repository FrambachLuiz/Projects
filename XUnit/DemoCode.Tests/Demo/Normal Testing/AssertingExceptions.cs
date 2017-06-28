using System;
using Xunit;

namespace DemoCode.Tests.Demo.Normal_Testing
{
    public class AssertingExceptions
    { 
        [Fact]
        public void ShouldErrorWhenDivideByZero()
        {
            var sut = new Calculator();

            Assert.Throws<DivideByZeroException>(() => sut.Divide(10, 0));
        }

        [Fact]
        public void ShouldErrorWhenNumberTooBig()
        {
            var sut = new Calculator();
            
            ArgumentOutOfRangeException throwException = 
                Assert.Throws<ArgumentOutOfRangeException>(() => sut.Divide(1000, 1));

            Assert.Equal("value" , throwException.ParamName);
        }
    }
}
