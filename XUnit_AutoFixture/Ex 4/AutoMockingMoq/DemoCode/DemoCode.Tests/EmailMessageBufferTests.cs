using System;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Xunit;

namespace DemoCode.Tests
{
    public class EmailMessageBufferTests
    {
        [Fact]
        public void ShouldSendEmailToGateway_Manual_Moq()
        {
            // arrange
            var fixture = new Fixture();

            var mockGateway = new Mock<IEmailGateway>();

            var sut = new EmailMessageBuffer(mockGateway.Object);

            sut.Add(fixture.Create<EmailMessage>());


            // act
            sut.SendAll();


            // assert
            mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once());
        }


        [Fact]
        public void ShouldSendEmailToGateway_WithoutAutoMoq_Error()
        {
            // arrange
            var fixture = new Fixture();

            var sut = fixture.Create<EmailMessageBuffer>(); // error
        }


        [Fact]
        public void ShouldSendEmailToGateway_AutoMoq()
        {
            // arrange
            var fixture = new Fixture();

            // add auto mocking support for Moq
            fixture.Customize(new AutoMoqCustomization());

            var sut = fixture.Create<EmailMessageBuffer>();

            sut.Add(fixture.Create<EmailMessage>());

            // act
            sut.SendAll();

            // assert
            // no reference to the mock IEmailGateway that was automatically provided
        }


        [Fact]
        public void ShouldSendEmailToGateway_AutoMoq_With_Freeze()
        {
            // arrange
            var fixture = new Fixture();

            // add auto mocking support for Moq
            fixture.Customize(new AutoMoqCustomization());

            var mockGateway = fixture.Freeze<Mock<IEmailGateway>>();

            var sut = fixture.Create<EmailMessageBuffer>();

            sut.Add(fixture.Create<EmailMessage>());


            // act
            sut.SendAll();


            // assert
            mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once());
        }

    }
}
