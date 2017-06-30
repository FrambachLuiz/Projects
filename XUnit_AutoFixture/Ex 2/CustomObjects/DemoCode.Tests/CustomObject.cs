using Ploeh.AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class CustomObject
    {
        [Fact]
        public void ManualCreation()
        {
            // arrange
            var sut = new EmailMessageBuffer();

            EmailMessage message = new EmailMessage("sarah@dontcodetired.com",
                                                    "Hello, hope you are well, Jason",
                                                    false);
            message.Subject = "Hi";

            // act
            sut.Add(message);

            // assert
            Assert.Equal(1, sut.Emails.Count);
        }


        [Fact]
        public void AutoCreation()
        {
            // arrange
            var fixture = new Fixture();
            var sut = new EmailMessageBuffer();

            EmailMessage message = fixture.Create<EmailMessage>();

            // act
            sut.Add(message);

            // assert
            Assert.Equal(1, sut.Emails.Count);
        }



    }
}
