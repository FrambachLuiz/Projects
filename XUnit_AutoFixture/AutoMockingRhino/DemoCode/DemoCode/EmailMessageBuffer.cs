using System.Collections.Generic;
using System.Linq;

namespace DemoCode
{
    public class EmailMessageBuffer
    {
        private readonly IEmailGateway _emailGateway;
        private readonly List<EmailMessage> _emails = new List<EmailMessage>();

        public EmailMessageBuffer(IEmailGateway emailGateway)
        {
            _emailGateway = emailGateway;
        }

        public int UnsentMessagesCount
        {
            get { return _emails.Count; }
        }


        public IEmailGateway EmailGateway
        {
            get { return _emailGateway; }
        }

        public void SendAll()
        {
            for (int i = 0; i < _emails.Count; i++)
            {
                var email = _emails[i];

                Send(email);
            }
        }

        private void Send(EmailMessage email)
        {
             _emailGateway.Send(email);

            _emails.Remove(email);
        }

        public void Add(EmailMessage message)
        {
            _emails.Add(message);
        }

        public void SendLimited(int maximumMessagesToSend)
        {
            var limitedBatchOfMessages = _emails.Take(maximumMessagesToSend).ToArray();

            for (int i = 0; i < limitedBatchOfMessages.Length; i++)
            {
                Send(limitedBatchOfMessages[i]);
            }
        }
    }
}