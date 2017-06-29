using System;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoRhinoMock;
using Rhino.Mocks;
using Xunit;



namespace DemoCode.Tests
{
    public class EmailMessageBufferTests
    {
        [Fact]
        public void ShouldSendEmailToGateway_Manual_Rhino()
        {
            // arrange
            var fixture = new Fixture();

            var mockGateway = MockRepository.GenerateStub<IEmailGateway>();

            var sut = new EmailMessageBuffer(mockGateway);  

            sut.Add(fixture.Create<EmailMessage>());
            

            // act
            sut.SendAll();


            // assert
            mockGateway.AssertWasCalled(x => x.Send(Arg<EmailMessage>.Is.NotNull));
        }



        [Fact]
        public void ShouldSendEmailToGateway_AutoRhino()
        {
            // arrange
            var fixture = new Fixture();

            // add auto mocking support for Rhino Mocks
            fixture.Customize(new AutoRhinoMockCustomization());

            IEmailGateway mockGateway = MockRepository.GenerateStub<IEmailGateway>();
            fixture.Inject(mockGateway);

            var sut = fixture.Create<EmailMessageBuffer>();

            sut.Add(fixture.Create<EmailMessage>());


            // act
            sut.SendAll();


            // assert
            mockGateway.AssertWasCalled(x => x.Send(Arg<EmailMessage>.Is.NotNull));
        }

   
    }
}
