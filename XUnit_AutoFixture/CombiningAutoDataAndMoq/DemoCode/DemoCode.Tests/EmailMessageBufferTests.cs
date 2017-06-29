using System;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;


namespace DemoCode.Tests
{
    public class EmailMessageBufferTests
    {

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







        [Theory]
        [AutoMoqData]
        public void ShouldSendEmailToGateway_AutoMoqData(EmailMessage message,
                                                         Mock<IEmailGateway> mockGateway,
                                                         EmailMessageBuffer sut)
        {
            // arrange
            sut.Add(message);

            // act
            sut.SendAll();

            // assert
            mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once());
        }









        [Theory]
        [AutoMoqData]
        public void ShouldSendEmailToGateway_AutoMoqData_With_Freeze(EmailMessage message,
                                                                     [Frozen] Mock<IEmailGateway> mockGateway,
                                                                     EmailMessageBuffer sut)
        {
            // arrange
            sut.Add(message);

            // act
            sut.SendAll();

            // assert
            mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once());
        }
    }
}
