using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.Extensions.Options;

namespace CRUDInventoryQuick.Services
{
    public class SmsSender : ISmsSender
    {
        public SmsOptions Options { get; }  // set only via Secret Manager

        public SmsSender(IOptions<SmsOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            // Your Account SID from twilio.com/console
            var accountSid = Options.SMSAccountIdentification;
            // Your Auth Token from twilio.com/console
            var authToken = Options.SMSAccountPassword;

            TwilioClient.Init(accountSid, authToken);

            return MessageResource.CreateAsync(
              to: new PhoneNumber(number),
              from: new PhoneNumber(Options.SMSAccountFrom),
              body: message);
        }
    }
}