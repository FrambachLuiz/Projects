using Xunit;

namespace DemoCode.Tests.Demo.Normal_Testing
{
    public class AssertingRanges
    {
        [Fact]
        public void ShouldIncreaseHealthAfterSleeping()
        {
            var sut = new PlayerCharacter { Health = 100};
            
            sut.Sleep();

            Assert.InRange(sut.Health, 101, int.MaxValue);
        }
    }
}
