using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.Services
{
    public class MessageSenderOptions
    {
        public string SendGridApiKey { get; set; }
        public string SiD { get; set; }
        public string AuthoToken { get; set; }
    }
}
