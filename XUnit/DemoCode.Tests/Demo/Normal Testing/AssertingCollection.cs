using Xunit;

namespace DemoCode.Tests.Demo.Normal_Testing
{
    public class AssertingCollection
    {
        [Fact]
        public void MethodName_Condition_ExpectedResult()
        {
            var sut = new PlayerCharacter();

            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));

        }

        [Fact]
        public void ShouldHaveALongBow()
        {
            var sut = new PlayerCharacter();

            Assert.Contains("Long Bow",sut.Weapons);
        }


        [Fact]
        public void ShouldHaveAStaffOfWonder()
        {
            var sut = new PlayerCharacter();

            Assert.DoesNotContain("Staff Of Wonder", sut.Weapons);
        }

        [Fact]
        public void ShouldHaveAtLeastOneKindOfSword()
        {
            var sut = new PlayerCharacter();

            Assert.Contains(sut.Weapons,weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void ShouldHaveAllExpectedWepons()
        {
            var sut = new PlayerCharacter();

            var expected = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };
            
            Assert.Equal(expected,sut.Weapons);

        }
    }
}
