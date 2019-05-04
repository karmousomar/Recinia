using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SendGrid;

namespace Recinia.Services
{
    public class MessageSend : IEmailSend, ISmsSend
    {
        public MessageSenderOptions Options { get; set; }
        public MessageSend(IOptions<MessageSenderOptions> optionsAccesor)
        {
            Options = optionsAccesor.Value;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            //throw new NotImplementedException();
            var myMessage = new SendGridMessage();
            myMessage.AddTo(email);
            myMessage.From = new MailAddress("karmous-omar@outlook.fr", "Admin Recinia");
            myMessage.Subject = subject;
            myMessage.Text = message;
            var apiKey = Options.SendGridApiKey;
            var transportWeb = new Web(apiKey);
            return transportWeb.DeliverAsync(myMessage);
        }

        public async Task SendSmsAsync(string number, string message)
        {
            using (var client = new HttpClient { BaseAddress = new Uri("http://api.twilio.com") })
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII
                    .GetBytes($"{ Options.SiD}:{Options.AuthoToken}")));
                var contentSms = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("To",$"+{number}"),
                    new KeyValuePair<string,string>("From",$"+12176456438"),
                    new KeyValuePair<string,string>("Body",message),
                });
                var results = await
                    client.PostAsync($"/2010-04-01/Accounts/{Options.SiD}/Message.json", contentSms).ConfigureAwait(false);
            }
        }
    }
}
