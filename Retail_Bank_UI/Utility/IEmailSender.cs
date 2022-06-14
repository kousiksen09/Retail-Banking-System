using System.Threading.Tasks;

namespace Retail_Bank_UI.Utility
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}