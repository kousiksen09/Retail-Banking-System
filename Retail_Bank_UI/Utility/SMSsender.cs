using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Retail_Bank_UI.Utility
{
    public class SMSsender : ISMSsender
    {
        private readonly SmsOptions smsOptions;
        public SMSsender(IOptions<SmsOptions> options)
        {
            smsOptions = options.Value;
        }
        public MessageResource SendSMS(string mobile, string content)
        {
            return Execute(smsOptions.TwilloSID, smsOptions.TwilloAuth, mobile, content);
        }

        private MessageResource Execute(string SID, string auth, string mobile, string message)
        {
            TwilioClient.Init(SID, auth);
            var msg = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber("+19705925910"),
                to: new Twilio.Types.PhoneNumber(mobile)
                ) ;
            return  msg;
        }
    }
}
