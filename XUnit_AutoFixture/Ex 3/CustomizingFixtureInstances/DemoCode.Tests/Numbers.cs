using Ploeh.AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class Numbers
    {
        [Fact]
        public void Ints()
        {
            // arrange
            var fixture = new Fixture();
            var sut = new IntCalculator();

            int num = fixture.Create<int>();

            // act
            sut.Add(num);

            // assert
            Assert.Equal(num, sut.Value);

        }

        [Fact]
        public void Decimals()
        {
            // arrange
            var fixture = new Fixture();
            var sut = new DecimalCalculator();

            decimal num = fixture.Create<decimal>();

            // act
            sut.Add(num);

            // assert
            Assert.Equal(num, sut.Value);
        }



        [Fact]
        public void OtherNumericTypes()
        {
            var fixture = new Fixture();


            byte b = fixture.Create<byte>();

            double d = fixture.Create<double>();

            short s = fixture.Create<short>();

            long l = fixture.Create<long>();

            sbyte sb = fixture.Create<sbyte>();

            float f = fixture.Create<float>();

            ushort us = fixture.Create<ushort>();

            uint ui = fixture.Create<uint>();

            ulong ul = fixture.Create<ulong>();

        }
    }
}
