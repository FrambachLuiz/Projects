using Xunit;

namespace DemoCode.Tests.Demo.Normal_Testing
{
    public class AssertingNullsBools
    {
        [Fact]
        public void ShouldHaveDefaulRandomGneretedName()
        {
            var sut  = new PlayerCharacter();
            
            Assert.False(string.IsNullOrWhiteSpace(sut.Name));

        }

        [Fact]
        public void ShouldNotHaveNickName()
        {
            var sut = new PlayerCharacter();
            
            Assert.Null(sut.NickName);
        }

        [Fact]
        public void ShouldBeNewbie()
        {
            var sut = new PlayerCharacter();

            Assert.True(sut.IsNoob);
        }
    }
}
