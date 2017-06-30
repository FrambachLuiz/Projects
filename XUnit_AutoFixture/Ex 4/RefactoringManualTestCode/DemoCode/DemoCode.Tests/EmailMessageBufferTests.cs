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
            var sut = new EmailMessageBuffer();          

            var message = new EmailMessage("sarah@dontcodetired.com",
                                           "Hi, hope you are good today, Jason",    
                                           true,
                                           "some subject");


            sut.Add(message);

            Assert.Equal(1, sut.UnsentMessagesCount);
        }


        [Fact]
        public void ShouldRemoveMessageFromBufferWhenSent()
        {
            var sut = new EmailMessageBuffer();

            var message = new EmailMessage("sarah@dontcodetired.com",
                                           "Hi, hope you are good today, Jason",
                                           true,
                                           "some subject");

            sut.Add(message);


            sut.SendAll();

            Assert.Equal(0, sut.UnsentMessagesCount);
        }


        [Fact]
        public void ShouldSendOnlySpecifiedNumberOfMessages()
        {
            var sut = new EmailMessageBuffer();

            var message1 = new EmailMessage("sarah001@dontcodetired.com",
                                           "Hi, hope you are good today, Jason",
                                           true,
                                           "some subject");


            var message2 = new EmailMessage("sarah002@dontcodetired.com",
                                            "Hi, hope you are good today, Jason",
                                            true,
                                            "some subject");

            var message3 = new EmailMessage("sarah002@dontcodetired.com",
                                            "Hi, hope you are good today, Jason",
                                            true,
                                            "some subject");
            
            sut.Add(message1);
            sut.Add(message2); 
            sut.Add(message3);

            sut.SendLimited(2);

            Assert.Equal(1, sut.UnsentMessagesCount);
        }


    }
}
