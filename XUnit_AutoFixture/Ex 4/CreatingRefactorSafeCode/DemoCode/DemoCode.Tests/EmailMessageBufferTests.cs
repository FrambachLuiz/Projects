using System;
using Ploeh.AutoFixture;
using Xunit;


namespace DemoCode.Tests
{
    public class EmailMessageBufferTests
    {
        [Fact]
        public void ShouldAddMessageToBuffer()
        {
            var fixture = new Fixture();
            var sut = new EmailMessageBuffer();


            sut.Add(fixture.Create<EmailMessage>());

            Assert.Equal(1, sut.UnsentMessagesCount);
        }


        [Fact]
        public void ShouldRemoveMessageFromBufferWhenSent()
        {
            var fixture = new Fixture();
            var sut = new EmailMessageBuffer();

            sut.Add(fixture.Create<EmailMessage>());


            sut.SendAll();

            Assert.Equal(0, sut.UnsentMessagesCount);
        }


        [Fact]
        public void ShouldSendOnlySpecifiedNumberOfMessages()
        {
            var fixture = new Fixture();
            var sut = new EmailMessageBuffer();

            sut.Add(fixture.Create<EmailMessage>());
            sut.Add(fixture.Create<EmailMessage>());
            sut.Add(fixture.Create<EmailMessage>());


            sut.SendLimited(2);

            Assert.Equal(1, sut.UnsentMessagesCount);
        }


    }
}
