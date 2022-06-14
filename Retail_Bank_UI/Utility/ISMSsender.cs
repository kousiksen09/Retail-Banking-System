using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace Retail_Bank_UI.Utility
{
    public interface ISMSsender
    {
        public MessageResource SendSMS(string mobile, string content);
    }
}
