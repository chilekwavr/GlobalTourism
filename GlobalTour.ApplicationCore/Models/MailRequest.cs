using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalTour.ApplicationCore.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }

    }
}
