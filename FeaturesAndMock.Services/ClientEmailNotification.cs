using MediatR;


namespace FeaturesAndMock.Services
{
    public class ClientEmailNotification : INotification
    {
        public string EmailSender { get; private set; }
        public string EmailRecipient { get; private set; }
        public string EmailSubject { get; private set; }
        public string EmailMessage { get; private set; }

        public ClientEmailNotification(string emailSender, string emailRecipient, string emailSubject, string emailMessage)
        {
            EmailSender = emailSender;
            EmailRecipient = emailRecipient;
            EmailSubject = emailSubject;
            EmailMessage = emailMessage;
        }
    }
}
