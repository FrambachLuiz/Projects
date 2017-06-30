using Ploeh.AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Traditional()
        {
            // Arrange

            var sut = new Calculator();

            // Act

            sut.Subtract(1);

            // Assert

            Assert.True(sut.Value < 0);
        }

        [Fact]
        public void Manual_Anonymous_Data()
        {
            // Arrange
            var sut = new Calculator();
            var anonymousNumber = 394;

            // Act
            sut.Subtract(anonymousNumber);

            // Assert
            Assert.True(sut.Value < 0);
        }


        [Fact]
        public void AutoFixture_Anonymous_Data()
        {
            // Arrange
            var sut = new Calculator();
            var fixture = new Fixture();

            // Act
            sut.Subtract(fixture.Create<int>());

            // Assert
            Assert.True(sut.Value < 0);
        }
    }
}
