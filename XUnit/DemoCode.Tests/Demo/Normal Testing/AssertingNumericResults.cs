using Xunit;

namespace DemoCode.Tests.Demo.Normal_Testing
{
    public class AssertingNumericResults
    {
        [Fact]
        public void ShouldAddIntValue()
        {
            var sut = new Calculator();
            var result = sut.AddInts(1, 2);

            Assert.Equal(3,result);
        }

        [Fact]
        public void SouldAddDoubleValues()
        {
            var sut = new Calculator();
            var result = sut.AddDoubles(1.1, 2.2);

            Assert.Equal(3.3,result,1);

        }
    }
}
