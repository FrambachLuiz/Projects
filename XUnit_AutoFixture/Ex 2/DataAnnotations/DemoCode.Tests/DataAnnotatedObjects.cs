using Ploeh.AutoFixture;
using Xunit;


namespace DemoCode.Tests
{
    public class DataAnnotatedObjects
    {
        [Fact]
        public void BasicString()
        {
            // arrange

            var fixture = new Fixture();

            var player = fixture.Create<PlayerCharacter>();


            // act and assert phases...

        }
    }
}
