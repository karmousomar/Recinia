using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Services
{
    public interface IEmailSend
    {
        Task SendEmailAsync(string email, string subjuct, string message);
    }
}
