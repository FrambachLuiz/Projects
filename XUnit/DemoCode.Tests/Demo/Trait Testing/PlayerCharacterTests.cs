using Xunit;
using Xunit.Abstractions;

namespace DemoCode.Tests.Demo.Trait_Testing
{
    public class PlayerCharacterTests
    {
        private readonly ITestOutputHelper _testOutput;

        public PlayerCharacterTests(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public void ShouldHaveNoEmptyDefaultWeapons()
        {
            var sut = new PlayerCharacter();

            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void ShouldHaveALongBow()
        {
            var sut = new PlayerCharacter();

            Assert.Contains("Long Bow", sut.Weapons);
        }


        [Fact]
        public void ShouldNotHaveAStaffOfWonder()
        {
            var sut = new PlayerCharacter();

            Assert.DoesNotContain("Staff Of Wonder", sut.Weapons);
        }


        [Fact]
        public void ShouldHaveAtLeastOneKindOfSword()
        {
            var sut = new PlayerCharacter();

            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
        }


        [Fact]
        public void ShouldHaveAllExpectedWeapons()
        {
            var sut = new PlayerCharacter();

            var expectedWeapons = new[]
                                  {
                                      "Long Bow",
                                      "Short Bow",
                                      "Short Sword"
                                  };


            Assert.Equal(expectedWeapons, sut.Weapons);
        }


        [Fact]
        public void ShouldIncreaseHealthAfterSleeping()
        {
            _testOutput.WriteLine("Creating PlayerCharacter");
            var sut = new PlayerCharacter { Health = 100 };

            _testOutput.WriteLine("PlayerCharacter going to sleep");
            sut.Sleep();

            _testOutput.WriteLine("PlawerCharacter awoken");
            Assert.InRange(sut.Health, 101, int.MaxValue);

        }
    }
}
